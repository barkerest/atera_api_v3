namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for alerts.
	/// </summary>
	public interface IAlertApiEndpoint : IReadCreateApiEndpoint<IAlert>,
	                                     IReadDeleteApiEndpoint<IAlert>
	{
		
	}
}
