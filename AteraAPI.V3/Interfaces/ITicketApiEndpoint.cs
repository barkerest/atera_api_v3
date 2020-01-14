using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for tickets.
	/// </summary>
	public interface ITicketApiEndpoint : IReadCreateApiEndpoint<ITicket>,
	                                      IReadUpdateApiEndpoint<ITicket>,
	                                      IReadDeleteApiEndpoint<ITicket>
	{
		IEnumerable<ITicket> GetResolvedAndClosed();

		Task<IEnumerable<ITicket>> GetResolvedAndClosedAsync();
		
		// TODO: Durations and comments.
	}
}
