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
		private ApiContext        _context;
		private ITestOutputHelper _output;

		public ApiContext_Should(TestSettings settings, ITestOutputHelper output)
		{
			_context = settings.GetApiContext();
			_output  = output ?? throw new ArgumentNullException(nameof(output));
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
				return;
			}

			var index      = customerCount == 1 ? 0 : 1;
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
			customer              = InternalModel.CreateInstanceOf<ICustomer>();
			customer.CustomerName = name;
			customer.City         = "Cleveland";

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
			customer       = customer2;
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

		[Fact]
		public void GetContacts()
		{
			_output.WriteLine("Enumerating contacts...");
			var contacts = _context.Contacts.ToArray();
			Assert.NotNull(contacts);

			_output.WriteLine("Getting count of contacts...");
			var contactCount = _context.Contacts.GetCount();
			Assert.Equal(contacts.Length, contactCount);

			if (contactCount == 0)
			{
				_output.WriteLine("No contacts, cannot continue this test.");
				return;
			}

			var index     = contactCount == 1 ? 0 : 1;
			var contactId = contacts[index].ContactID;
			_output.WriteLine($"Loading contact ID={contactId}...");
			var contact = _context.Contacts.Find(contactId);
			Assert.NotNull(contact);

			Assert.Equal(contactId, contact.ContactID);
			Assert.Equal(contacts[index].Email, contact.Email);
		}

		[Fact]
		public void CreateUpdateDeleteContacts()
		{
			var email = "my-test-contact@safe.to.delete";

			var contact = _context.Contacts.FirstOrDefault(x => string.Equals(email, x.Email));
			if (contact != null)
			{
				_output.WriteLine("Trying to remove old test, which shouldn't be here.");
				Assert.True(_context.Contacts.Delete(contact));
			}

			_output.WriteLine("Creating test contact...");
			contact       = InternalModel.CreateInstanceOf<IContact>();
			contact.Email = email;

			var contactId = _context.Contacts.Create(contact);
			Assert.NotEqual(0, contactId);

			_output.WriteLine("Loading test contact...");
			var contact2 = _context.Contacts.Find(contactId);
			Assert.NotNull(contact2);
			Assert.Equal(contactId, contact2.ContactID);
			Assert.Equal(contact.Email, contact2.Email);
			Assert.Null(contact2.FirstName);
			
			_output.WriteLine("Updating test contact...");
			contact       = contact2;
			contact.FirstName = "Joe";
			Assert.True(_context.Contacts.Update(contact));

			_output.WriteLine("Re-loading test contact...");
			contact2 = _context.Contacts.Find(contact.ContactID);
			Assert.NotNull(contact2);
			Assert.Equal(contact.ContactID, contact2.ContactID);
			Assert.Equal(contact.Email, contact2.Email);
			Assert.Equal(contact.FirstName, contact2.FirstName);

			_output.WriteLine("Removing test contact...");
			Assert.True(_context.Contacts.Delete(contact));
		}

		[Fact]
		public void GetAgents()
		{
			_output.WriteLine("Enumerating agents...");
			var agents = _context.Agents.ToArray();
			Assert.NotNull(agents);

			_output.WriteLine("Getting count of agents...");
			var agentCount = _context.Agents.GetCount();
			Assert.Equal(agents.Length, agentCount);

			if (agentCount == 0)
			{
				_output.WriteLine("No agents, cannot continue this test.");
				return;
			}

			var testAgent = agents.FirstOrDefault(x => x.HardwareDisks != null && x.HardwareDisks.Length > 0)
			                ?? agents[agentCount == 1 ? 0 : 1];
			var agentId = testAgent.AgentID;
			_output.WriteLine($"Loading agent ID={agentId}...");
			var agent = _context.Agents.Find(agentId);
			Assert.NotNull(agent);

			Assert.Equal(agentId, agent.AgentID);
			Assert.Equal(testAgent.AgentName, agent.AgentName);
			
			if (testAgent.HardwareDisks is null || testAgent.HardwareDisks.Length < 1)
			{
				_output.WriteLine("Test agent has no hardware disks, cannot complete this test.");
				return;
			}
			
			Assert.NotNull(agent.HardwareDisks);
			Assert.Equal(testAgent.HardwareDisks.Length, agent.HardwareDisks.Length);
			
		}
		
		
	}
}
