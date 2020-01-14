namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for rates.
	/// </summary>
	public interface IRateApiEndpoint : IReadCreateApiEndpoint<IRate>,
	                                    IReadUpdateApiEndpoint<IRate>,
	                                    IReadDeleteApiEndpoint<IRate>
	{
		
	}
}
