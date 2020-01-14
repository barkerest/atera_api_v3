namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for customers.
	/// </summary>
	public interface ICustomerApiEndpoint : IReadCreateApiEndpoint<ICustomer>,
	                                        IReadUpdateApiEndpoint<ICustomer>,
	                                        IReadDeleteApiEndpoint<ICustomer>
	{
		
	}
}
