using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for tickets.
	/// </summary>
	public interface ITicket
	{
		/// <summary>
		/// The ticket ID.
		/// </summary>
		int TicketID { get; }
		
		/// <summary>
		/// The title of the ticket.
		/// </summary>
		string TicketTitle { get; set; }
		
		/// <summary>
		/// A unique number for the ticket based on a timestamp.
		/// </summary>
		string TicketNumber { get; set; }
		
		/// <summary>
		/// The priority of the ticket.
		/// </summary>
		string TicketPriority { get; set; }
		
		/// <summary>
		/// The impact of the ticket.
		/// </summary>
		string TicketImpact { get; set; }
		
		/// <summary>
		/// The status of the ticket.
		/// </summary>
		string TicketStatus { get; set; }
		
		/// <summary>
		/// The source of the ticket.
		/// </summary>
		string TicketSource { get; set; }
		
		/// <summary>
		/// The type of ticket.
		/// </summary>
		string TicketType { get; set; }
		
		/// <summary>
		/// The end user (contact) attached to the ticket.
		/// </summary>
		int EndUserID { get; set; }
		
		/// <summary>
		/// The email of the end user.
		/// </summary>
		string EndUserEmail { get; set; }
		
		/// <summary>
		/// The first name of the end user.
		/// </summary>
		string EndUserFirstName { get; set; }
		
		/// <summary>
		/// The last name of the end user.
		/// </summary>
		string EndUserLastName { get; set; }
		
		/// <summary>
		/// The phone of the end user.
		/// </summary>
		string EndUserPhone { get; set; }
		
		/// <summary>
		/// When was the ticket resolved.
		/// </summary>
		DateTime? TicketResolvedDate { get; }
		
		/// <summary>
		/// When was the ticket created.
		/// </summary>
		DateTime TicketCreatedDate { get; }
		
		/// <summary>
		/// When was the first technician comment.
		/// </summary>
		DateTime? TechnicianFirstCommentDate { get; }
		
		/// <summary>
		/// When is the first response due.
		/// </summary>
		DateTime? FirstResponseDueDate { get; }
		
		/// <summary>
		/// When must the ticket be closed.
		/// </summary>
		DateTime? ClosedTicketDueDate { get; }
		
		/// <summary>
		/// The first comment on the ticket.
		/// </summary>
		string FirstComment { get; }
		
		/// <summary>
		/// The last comment from the end user.
		/// </summary>
		string LastEndUserComment { get; }
		
		/// <summary>
		/// The date/time the end user last commented.
		/// </summary>
		DateTime? LastEndUserCommentTimestamp { get; }
		
		/// <summary>
		/// The last comment from the technician.
		/// </summary>
		string LastTechnicianComment { get; }
		
		/// <summary>
		/// The date/time the technician last commented.
		/// </summary>
		DateTime? LastTechnicianCommentTimestamp { get; }
		
		/// <summary>
		/// Seconds on site.
		/// </summary>
		int? OnSiteDurationSeconds { get; }
		
		/// <summary>
		/// Minutes on site.
		/// </summary>
		int? OnSiteDurationMinutes { get; }
		
		/// <summary>
		/// Seconds off site.
		/// </summary>
		int? OffSiteDurationSeconds { get; }
		
		/// <summary>
		/// Minutes off site.
		/// </summary>
		int? OffSiteDurationMinutes { get; }
		
		/// <summary>
		/// Seconds within the SLA.
		/// </summary>
		int? OnSLADurationSeconds { get; }
		
		/// <summary>
		/// Minutes within the SLA.
		/// </summary>
		int? OnSLADurationMinutes { get; }
		
		/// <summary>
		/// Seconds outside the SLA.
		/// </summary>
		int? OffSLADurationSeconds { get; }
		
		/// <summary>
		/// Minutes outside the SLA.
		/// </summary>
		int? OffSLADurationMinutes { get; }
		
		/// <summary>
		/// Total number of seconds spent on this ticket.
		/// </summary>
		int? TotalDurationSeconds { get; }
		
		/// <summary>
		/// Total number of minutes spent on this ticket.
		/// </summary>
		int? TotalDurationMinutes { get; }
		
		/// <summary>
		/// The customer this ticket is assigned under. 
		/// </summary>
		int CustomerID { get; }
		
		/// <summary>
		/// The customer this ticket is assigned under.
		/// </summary>
		string CustomerName { get; }
		
		/// <summary>
		/// The tax ID number for the customer this ticket is assigned.
		/// </summary>
		string CustomerBusinessNumber { get; }
		
		/// <summary>
		/// The technician assigned to the ticket.
		/// </summary>
		int? TechnicianContactID { get; set; }
		
		/// <summary>
		/// The technician assigned to the ticket.
		/// </summary>
		string TechnicianFullName { get; }
		
		/// <summary>
		/// The email of the technician assigned to the ticket.
		/// </summary>
		string TechnicianEmail { get; }
		
	}
}
