using System;
using System.Linq;
using AteraAPI.V3.Interfaces;
using AteraAPI.V3.Tests.Config;
using Xunit;
using Xunit.Abstractions;

namespace AteraAPI.V3.Tests
{
	public class ApiContext_Should : IClassFixture<TestSettings>
	{
		private ApiContext _context;
		private ITestOutputHelper _output;
		
		public ApiContext_Should(TestSettings settings, ITestOutputHelper output)
		{
			_context = settings.GetApiContext();
			_output = output ?? throw new ArgumentNullException(nameof(output));
		}
		
		[Fact]
		public void GetCustomers()
		{
			_output.WriteLine("Enumerating customers...");
			var customers = _context.Customers.ToArray();
			Assert.NotNull(customers);
			
			_output.WriteLine("Getting count of customers...");
			var customerCount = _context.Customers.GetCount();
			Assert.Equal(customers.Length, customerCount);

			if (customerCount == 0)
			{
				_output.WriteLine("No customers, cannot continue this test.");
			}

			var index = customerCount == 1 ? 0 : 1;
			var customerId = customers[index].CustomerID;
			_output.WriteLine($"Loading customer ID={customerId}...");
			var customer = _context.Customers.Find(customerId);
			Assert.NotNull(customer);
			
			Assert.Equal(customerId, customer.CustomerID);
			Assert.Equal(customers[index].CustomerName, customer.CustomerName);
		}

		[Fact]
		public void CreateUpdateDeleteCustomers()
		{
			var name = "MyTestCustomer(SafeToDelete)";

			var customer = _context.Customers.FirstOrDefault(x => string.Equals(name, x.CustomerName));
			if (customer != null)
			{
				_output.WriteLine("Trying to remove old test, which shouldn't be here.");
				Assert.True(_context.Customers.Delete(customer));
			}
			
			_output.WriteLine("Creating test customer...");
			customer = InternalModel.CreateInstanceOf<ICustomer>();
			customer.CustomerName = name;
			customer.City = "Cleveland";
			
			var customerId = _context.Customers.Create(customer);
			Assert.NotEqual(0, customerId);

			_output.WriteLine("Loading test customer...");
			var customer2 = _context.Customers.Find(customerId);
			Assert.NotNull(customer2);
			Assert.Equal(customerId, customer2.CustomerID);
			Assert.Equal(customer.CustomerName, customer2.CustomerName);
			Assert.Equal(customer.City, customer2.City);
			Assert.Null(customer2.State);

			_output.WriteLine("Updating test customer...");
			customer = customer2;
			customer.State = "Ohio";
			Assert.True(_context.Customers.Update(customer));
			
			_output.WriteLine("Re-loading test customer...");
			customer2 = _context.Customers.Find(customer.CustomerID);
			Assert.NotNull(customer2);
			Assert.Equal(customer.CustomerID, customer2.CustomerID);
			Assert.Equal(customer.CustomerName, customer2.CustomerName);
			Assert.Equal(customer.City, customer2.City);
			Assert.Equal(customer.State, customer2.State);

			_output.WriteLine("Removing test customer...");
			Assert.True(_context.Customers.Delete(customer));
		}
	}
}
