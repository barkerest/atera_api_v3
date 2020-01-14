namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for contacts.
	/// </summary>
	public interface IContactApiEndpoint : IReadCreateApiEndpoint<IContact>,
	                                       IReadUpdateApiEndpoint<IContact>,
	                                       IReadDeleteApiEndpoint<IContact>
	{
		
	}
}
