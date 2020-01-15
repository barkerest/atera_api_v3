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
		/// <summary>
		/// Gets resolved and closed tickets.
		/// </summary>
		/// <returns></returns>
		IEnumerable<ITicket> GetResolvedAndClosed();

		/// <summary>
		/// Gets the billable duration for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		IDuration GetBillableDuration(int ticketId);
		
		/// <summary>
		/// Gets the non-billable duration for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		IDuration GetNonBillableDuration(int ticketId);

		/// <summary>
		/// Gets the work hours for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		IWorkHours GetWorkHours(int ticketId);

		/// <summary>
		/// Gets work hour records for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		IEnumerable<IWorkHourRecord> GetWorkHourRecords(int ticketId);

		/// <summary>
		/// Gets comments for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		IEnumerable<IComment> GetComments(int ticketId);
		
		
		/// <summary>
		/// Gets resolved and closed tickets.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ITicket>> GetResolvedAndClosedAsync();

		/// <summary>
		/// Gets the billable duration for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		Task<IDuration> GetBillableDurationAsync(int ticketId);

		/// <summary>
		/// Gets the non-billable duration for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		Task<IDuration> GetNonBillableDurationAsync(int ticketId);

		/// <summary>
		/// Gets the work hours for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		Task<IWorkHours> GetWorkHoursAsync(int ticketId);

		/// <summary>
		/// Gets work hour records for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		Task<IEnumerable<IWorkHourRecord>> GetWorkHourRecordsAsync(int ticketId);

		/// <summary>
		/// Gets comments for a ticket.
		/// </summary>
		/// <param name="ticketId"></param>
		/// <returns></returns>
		Task<IEnumerable<IComment>> GetCommentsAsync(int ticketId);
	}
}
