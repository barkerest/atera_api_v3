using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AteraAPI.V3.Interfaces;
using AteraAPI.V3.Tests.Config;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AteraAPI.V3.Tests
{
	public class ApiContext_Should : IClassFixture<TestSettings>
	{
		private ApiContext        _context;
		private ITestOutputHelper _output;

		public ApiContext_Should(TestSettings settings, ITestOutputHelper output)
		{
			_context = settings.GetApiContext();
			_output  = output ?? throw new ArgumentNullException(nameof(output));
		}

		#region API Test Helpers

		private string ItemText<TModel>()
		{
			var name = InternalModel.TypeFor(typeof(TModel))?.Name ?? typeof(TModel).Name;
			if (name.Contains(".")) name = name.Split('.', 2).Last();
			return name;
		}

		private void TestReadOnlyApi<TModel>(
			IReadOnlyApiEndpoint<TModel> apiEndpoint,
			Func<TModel, int>            getId,
			Func<TModel[], int>          selectIndex = null
		) where TModel : class
		{
			var itemText = ItemText<TModel>();
			var itemsText = itemText + "s";

			if (selectIndex == null)
			{
				selectIndex = list => (list.Length == 1 ? 0 : 1);
			}

			_output.WriteLine($"Enumerating {itemsText}...");
			var items = apiEndpoint.ToArray();
			Assert.NotNull(items);

			_output.WriteLine($"Getting count of {itemsText}...");
			var itemCount = apiEndpoint.GetCount();
			Assert.Equal(items.Length, itemCount);

			if (itemCount == 0)
			{
				_output.WriteLine($"No {itemsText}, cannot continue this test.");
				return;
			}

			var index  = selectIndex(items);
			var itemId = getId(items[index]);
			_output.WriteLine($"Loading {itemsText} ID={itemId}...");
			var item = apiEndpoint.Find(itemId);
			Assert.NotNull(item);
			Assert.Equal(itemId, getId(item));

			Assert.Equal(items[index], item);
			Assert.False(ReferenceEquals(items[index], item));
		}

		private PropertyInfo GetProperty(LambdaExpression lex)
		{
			var mex = lex.Body as MemberExpression;
			if (mex is null && lex.Body is UnaryExpression uex && uex.NodeType == ExpressionType.Convert)
			{
				mex = uex.Operand as MemberExpression;
			}

			if (mex is null) throw new ArgumentException($"Not a member expression: {lex}");
			return (mex.Member as PropertyInfo) ?? throw new ArgumentException($"Not a property expression: {lex}");
		}

		private TModel TestCreateApi<TModel>(IReadCreateApiEndpoint<TModel> api, Func<TModel, int> getId, Action<TModel> init, params Expression<Func<TModel, object>>[] propsToTest)
			where TModel : class
		{
			var itemText = ItemText<TModel>();
			_output.WriteLine($"Creating test {itemText}...");
			var item = InternalModel.CreateInstanceOf<TModel>();
			init(item);

			var itemId = api.Create(item);
			Assert.NotEqual(0, itemId);

			_output.WriteLine($"Loading test {itemText}...");
			var newItem = api.Find(itemId);
			Assert.NotNull(newItem);
			Assert.Equal(itemId, getId(newItem));

			foreach (var propToTest in propsToTest)
			{
				var prop = GetProperty(propToTest);
				var valA = prop.GetValue(item);
				var valB = prop.GetValue(newItem);
				if (valA is null && valB is null) continue;
				if (valA is null || valB is null || !valA.Equals(valB))
				{
					if (valA is null) valA = "(null)";
					if (valB is null) valB = "(null)";
					
					throw new XunitException($"Property {prop.Name} differs.\nExpected: {valA}\nActual:   {valB}");
				}
			}

			return newItem;
		}

		private TModel TestUpdateApi<TModel>(IReadUpdateApiEndpoint<TModel> api, TModel item, Func<TModel, int> getId, Action<TModel> update, params Expression<Func<TModel, object>>[] propsToTest)
			where TModel : class
		{
			var itemText = ItemText<TModel>();
			_output.WriteLine($"Updating test {itemText}...");
			update(item);
			Assert.True(api.Update(item));

			var itemId = getId(item);
			_output.WriteLine($"Re-loading test {itemText}...");
			var newItem = api.Find(itemId);
			Assert.NotNull(newItem);
			Assert.Equal(itemId, getId(newItem));

			foreach (var propToTest in propsToTest)
			{
				var prop = GetProperty(propToTest);
				var valA = prop.GetValue(item);
				var valB = prop.GetValue(newItem);
				if (valA is null && valB is null) continue;
				if (valA is null || valB is null || !valA.Equals(valB))
				{
					if (valA is null) valA = "(null)";
					if (valB is null) valB = "(null)";
					
					throw new XunitException($"Property {prop.Name} differs.\nExpected: {valA}\nActual:   {valB}");
				}
			}

			return newItem;
		}

		private void TestDeleteApi<TModel>(IReadDeleteApiEndpoint<TModel> api, TModel item, Func<TModel, int> getId, Action<TModel> testDeleted) where TModel : class
		{
			var itemText = ItemText<TModel>();
			_output.WriteLine($"Removing test {itemText}...");
			var itemId = getId(item);
			Assert.True(api.Delete(item));

			_output.WriteLine($"Attempting to re-load test {itemText}...");
			item = api.Find(itemId);
			testDeleted(item);
		}

		private void RemovePreviousTest<TModel>(IReadDeleteApiEndpoint<TModel> api, Func<IReadOnlyApiEndpoint<TModel>, int?> findTestId) where TModel : class
		{
			var previousId = findTestId(api);
			if (previousId.HasValue)
			{
				var itemText = ItemText<TModel>();
				_output.WriteLine($"Removing previous test {itemText} (should not be here)...");
				Assert.True(api.Delete(previousId.Value));
			}
		}

		private void TestCreateUpdateDeleteApi<TModel>(
			IReadOnlyApiEndpoint<TModel>              api,
			Func<IReadOnlyApiEndpoint<TModel>, int?>  findTestId,
			Func<TModel, int>                         getId,
			Action<TModel>                            init,
			Action<TModel>                            update,
			Action<TModel>                            testDeleted,
			params Expression<Func<TModel, object>>[] propsToTest
		)
			where TModel : class
		{
			var createApi = api as IReadCreateApiEndpoint<TModel> ?? throw new ArgumentException("Does not implement Create api.");
			var updateApi = api as IReadUpdateApiEndpoint<TModel> ?? throw new ArgumentException("Does not implement Update api.");
			var deleteApi = api as IReadDeleteApiEndpoint<TModel> ?? throw new ArgumentException("Does not implement Delete api.");

			RemovePreviousTest(deleteApi, findTestId);

			var item = TestCreateApi(createApi, getId, init, propsToTest);
			item = TestUpdateApi(updateApi, item, getId, update, propsToTest);
			TestDeleteApi(deleteApi, item, getId, testDeleted);
		}

		private void TestCreateDeleteApi<TModel>(
			IReadOnlyApiEndpoint<TModel>              api,
			Func<IReadOnlyApiEndpoint<TModel>, int?>  findTestId,
			Func<TModel, int>                         getId,
			Action<TModel>                            init,
			Action<TModel>                            testDeleted,
			params Expression<Func<TModel, object>>[] propsToTest
		)
			where TModel : class
		{
			var createApi = api as IReadCreateApiEndpoint<TModel> ?? throw new ArgumentException("Does not implement Create api.");
			var deleteApi = api as IReadDeleteApiEndpoint<TModel> ?? throw new ArgumentException("Does not implement Delete api.");

			RemovePreviousTest(deleteApi, findTestId);

			var item = TestCreateApi(createApi, getId, init, propsToTest);
			TestDeleteApi(deleteApi, item, getId, testDeleted);
		}

		#endregion

		#region Agents

		// The Agent API supports deleting, but not creating.
		// We cannot safely test the Delete action.

		[Fact]
		public void GetAgents()
		{
			TestReadOnlyApi(
				_context.Agents,
				a => a.AgentID,
				list =>
				{
					var md = 0;
					var mi = -1;
					for (var i = 0; i < list.Length; i++)
					{
						var item = list[i];
						if (item.HardwareDisks != null && item.HardwareDisks.Length > 0)
						{
							if (item.HardwareDisks.Length > md)
							{
								mi = i;
								md = item.HardwareDisks.Length;
							}
						}
					}

					if (mi > 0)
					{
						_output.WriteLine($"Found agent with {md} disks, using index {mi}.");
						return mi;
					}

					_output.WriteLine("No agents with hardware disks, falling back on default index selection.");
					return list.Length == 1 ? 0 : 1;
				});
		}

		#endregion

		#region Alerts

		[Fact]
		public void GetAlerts()
		{
			TestReadOnlyApi(_context.Alerts, a => a.AlertID);
		}

		[Fact]
		public void CreateDeleteAlerts()
		{
			var agent = _context.Agents.FirstOrDefault() ?? throw new XunitException("No agent to create an alert for.");
			var cust  = _context.Customers.Find(agent.CustomerID) ?? throw new XunitException("No customer to create an alert for.");
			var title = "A test alert";

			TestCreateDeleteApi(
				_context.Alerts,
				api => api.FirstOrDefault(x => string.Equals(title, x.Title))?.AlertID,
				x => x.AlertID,
				x =>
				{
					x.CustomerID   = cust.CustomerID;
					x.DeviceGuid   = agent.DeviceGuid;
					x.Code         = 202;
					x.Severity     = "Information";
					x.Title        = title;
				},
				Assert.Null,
				x => x.CustomerID,
				x => x.DeviceGuid,
				x => x.Code,
				x => x.Severity,
				x => x.Title
			);
		}

		#endregion

		#region Billing / Invoices

		[Fact]
		public void GetInvoices()
		{
			TestReadOnlyApi(_context.Invoices, i => i.InvoiceNumber);
		}

		#endregion

		#region Contacts

		[Fact]
		public void GetContacts()
		{
			TestReadOnlyApi(_context.Contacts, c => c.ContactID);
		}

		[Fact]
		public void CreateUpdateDeleteContacts()
		{
			var email = "safe-to-delete@example.com";

			TestCreateUpdateDeleteApi(
				_context.Contacts,
				api => api.FirstOrDefault(x => string.Equals(email, x.Email))?.ContactID,
				x => x.ContactID,
				x =>
				{
					x.Email    = email;
					x.LastName = "Smith";
				},
				x => { x.FirstName = "Joe"; },
				Assert.Null,
				x => x.Email,
				x => x.FirstName,
				x => x.LastName
			);
		}

		#endregion

		#region Contracts

		[Fact]
		public void GetContracts()
		{
			TestReadOnlyApi(_context.Contracts, c => c.ContractID);
		}

		[Fact]
		public void GetContractsByCustomer()
		{
			var cust = _context.Customers.FirstOrDefault() ?? throw new XunitException("No customer to search with.");
			var data = _context.Contracts.FindByCustomer(cust.CustomerID)?.ToArray();
			Assert.NotNull(data);
			Assert.NotEmpty(data);
		}

		#endregion

		#region Customers

		[Fact]
		public void GetCustomers()
		{
			TestReadOnlyApi(_context.Customers, c => c.CustomerID);
		}

		[Fact]
		public void CreateUpdateDeleteCustomers()
		{
			var name = "MyTestCustomer(SafeToDelete)";

			TestCreateUpdateDeleteApi(
				_context.Customers,
				api => api.FirstOrDefault(x => string.Equals(name, x.CustomerName))?.CustomerID,
				x => x.CustomerID,
				x =>
				{
					x.CustomerName = name;
					x.City         = "Cleveland";
				},
				x => { x.State = "Ohio"; },
				Assert.Null,
				x => x.CustomerName,
				x => x.City,
				x => x.State
			);
		}

		#endregion

		#region Custom Values

		// no way to test custom values without setting something up via the portal.
		// this would require setting up a custom value with a known name for one or more of the target data types.
		// then the custom value would need to be set in a target item.
		// and finally we'd be able to test our ability to read the custom value by using the ID for the known target item.

		#endregion

		#region Knowledge Base

		[Fact]
		public void GetKnowledgeBases()
		{
			TestReadOnlyApi(_context.KnowledgeBase, x => x.KBID);
		}

		#endregion

		#region Rates

		[Fact]
		public void GetProductRates()
		{
			TestReadOnlyApi(_context.ProductRates, x => x.RateID);
		}

		[Fact]
		public void GetExpenseRates()
		{
			TestReadOnlyApi(_context.ExpenseRates, x => x.RateID);
		}

		[Fact]
		public void CreateUpdateDeleteProductRates()
		{
			var desc = "My Test Product Rate";
			TestCreateUpdateDeleteApi(
				_context.ProductRates,
				api => api.FirstOrDefault(x => string.Equals(desc, x.Description))?.RateID,
				x => x.RateID,
				x =>
				{
					x.Category    = "Test";
					x.Description = desc;
					x.Amount      = 102.03;
				},
				x => { x.SKU = "123456Z"; },
				Assert.Null,
				x => x.Category,
				x => x.Description,
				x => x.Amount,
				x => x.SKU
			);
		}

		[Fact]
		public void CreateUpdateDeleteExpenseRates()
		{
			var desc = "My Test Expense Rate";
			TestCreateUpdateDeleteApi(
				_context.ExpenseRates,
				api => api.FirstOrDefault(x => string.Equals(desc, x.Description))?.RateID,
				x => x.RateID,
				x =>
				{
					x.Category    = "Test";
					x.Description = desc;
					x.Amount      = 102.03;
				},
				x => { x.SKU = "123456Z"; },
				Assert.Null,
				x => x.Category,
				x => x.Description,
				x => x.Amount,
				x => x.SKU
			);
		}

		#endregion

		#region Tickets

		[Fact]
		public void GetTickets()
		{
			TestReadOnlyApi(_context.Tickets, x => x.TicketID);
		}

		[Fact]
		public void CreateUpdateDeleteTickets()
		{
			var title   = "A test ticket from API";
			var endUser = _context.Contacts.FirstOrDefault() ?? throw new XunitException("No contacts to create test ticket with.");

			TestCreateUpdateDeleteApi(
				_context.Tickets,
				api => api.FirstOrDefault(x => string.Equals(title, x.TicketTitle) && !string.Equals("Deleted", x.TicketStatus))?.TicketID,
				x => x.TicketID,
				x =>
				{
					x.TicketTitle    = title;
					x.Description    = "This is only a test.";
					x.EndUserID      = endUser.ContactID;
					x.TicketPriority = "Low";
				},
				x => { x.TicketPriority = "High"; },
				x =>
				{
					Assert.NotNull(x);
					Assert.Equal("Deleted", x.TicketStatus);
				},
				x => x.TicketTitle,
				x => x.Description,
				x => x.EndUserID,
				x => x.TicketPriority
			);
		}

		[Fact]
		public void GetResolvedAndClosedTickets()
		{
			var result = _context.Tickets.GetResolvedAndClosed()?.ToArray();
			Assert.NotNull(result);
		}

		[Fact]
		public void GetAdditionalTicketInformation()
		{
			var ticket = _context.Tickets.FirstOrDefault() ?? throw new XunitException("No ticket to read details from.");

			Assert.NotNull(_context.Tickets.GetBillableDuration(ticket.TicketID));
			Assert.NotNull(_context.Tickets.GetNonBillableDuration(ticket.TicketID));
			Assert.NotNull(_context.Tickets.GetWorkHours(ticket.TicketID));
			Assert.NotNull(_context.Tickets.GetWorkHourRecords(ticket.TicketID)?.ToArray());
			Assert.NotNull(_context.Tickets.GetComments(ticket.TicketID)?.ToArray());
		}

		#endregion
	}
}
