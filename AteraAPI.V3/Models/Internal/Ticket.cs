using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class Ticket : ITicket
	{
		public int TicketID { get; set; }
		public bool ShouldSerializeTicketID() => false;
		
		public string TicketTitle { get; set; }
		
		public string TicketNumber { get; set; }
		public bool ShouldSerializeTicketNumber() => false;
		
		public string TicketPriority { get; set; }
		public string TicketImpact { get; set; }
		public string TicketStatus { get; set; }
		
		public string TicketSource { get; set; }
		public bool ShouldSerializeTicketSource() => false;
		
		public string TicketType { get; set; }
		
		public int EndUserID { get; set; }
		public bool ShouldSerializeEndUserID() => (TicketID == 0);
		
		public string EndUserEmail { get; set; }
		public bool ShouldSerializeEndUserEmail() => (TicketID == 0);
		
		public string EndUserFirstName { get; set; }
		public bool ShouldSerializeEndUserFirstName() => (TicketID == 0);
		
		public string EndUserLastName { get; set; }
		public bool ShouldSerializeEndUserLastName() => (TicketID == 0);
		
		public string EndUserPhone { get; set; }
		public bool ShouldSerializeEndUserPhone() => false;
		
		public DateTime? TicketResolvedDate { get; set; }
		public bool ShouldSerializeTicketResolvedDate() => false;
		
		public DateTime TicketCreatedDate { get; set; }
		public bool ShouldSerializeTicketCreatedDate() => false;
		
		public DateTime? TechnicianFirstCommentDate { get; set; }
		public bool ShouldSerializeTechnicianFirstCommentDate() => false;
		
		public DateTime? FirstResponseDueDate { get; set; }
		public bool ShouldSerializeFirstResponseDueDate() => false;
		
		public DateTime? ClosedTicketDueDate { get; set; }
		public bool ShouldSerializeClosedTicketDueDate() => false;
		
		public string FirstComment { get; set; }
		public bool ShouldSerializeFirstComment() => false;
		
		public string LastEndUserComment { get; set; }
		public bool ShouldSerializeLastEndUserComment() => false;
		
		public DateTime? LastEndUserCommentTimestamp { get; set; }
		public bool ShouldSerializeLastEndUserCommentTimestamp() => false;
		
		public string LastTechnicianComment { get; set; }
		public bool ShouldSerializeLastTechnicianComment() => false;
		
		public DateTime? LastTechnicianCommentTimestamp { get; set; }
		public bool ShouldSerializeLastTechnicianCommentTimestamp() => false;
		
		public int? OnSiteDurationSeconds { get; set; }
		public bool ShouldSerializeOnSiteDurationSeconds() => false;
		
		public int? OnSiteDurationMinutes { get; set; }
		public bool ShouldSerializeOnSiteDurationMinutes() => false;
		
		public int? OffSiteDurationSeconds { get; set; }
		public bool ShouldSerializeOffSiteDurationSeconds() => false;
		
		public int? OffSiteDurationMinutes { get; set; }
		public bool ShouldSerializeOffSiteDurationMinutes() => false;
		
		public int? OnSLADurationSeconds { get; set; }
		public bool ShouldSerializeOnSLADurationSeconds() => false;
		
		public int? OnSLADurationMinutes { get; set; }
		public bool ShouldSerializeOnSLADurationMinutes() => false;
		
		public int? OffSLADurationSeconds { get; set; }
		public bool ShouldSerializeOffSLADurationSeconds() => false;
		
		public int? OffSLADurationMinutes { get; set; }
		public bool ShouldSerializeOffSLADurationMinutes() => false;
		
		public int? TotalDurationSeconds { get; set; }
		public bool ShouldSerializeTotalDurationSeconds() => false;
		
		public int? TotalDurationMinutes { get; set; }
		public bool ShouldSerializeTotalDurationMinutes() => false;
		
		public int CustomerID { get; set; }
		public bool ShouldSerializeCustomerID() => false;
		
		public string CustomerName { get; set; }
		public bool ShouldSerializeCustomerName() => false;
		
		public string CustomerBusinessNumber { get; set; }
		public bool ShouldSerializeCustomerBusinessNumber() => false;
		
		public int? TechnicianContactID { get; set; }
		
		public string TechnicianFullName { get; set; }
		public bool ShouldSerializeTechnicianFullName() => false;
		
		public string TechnicianEmail { get; set; }
		public bool ShouldSerializeTechnicianEmail() => false;
	}
}
