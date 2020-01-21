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
		public string TicketImpact   { get; set; }
		public string TicketStatus   { get; set; }

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

		private string _newDescription;

		public string Description
		{
			get => (TicketID == 0) ? _newDescription : FirstComment;
			set => _newDescription = value;
		}
		public bool ShouldSerializeDescription() => (TicketID == 0);

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

		public override string ToString()
		{
			return $"Ticket {TicketID}";
		}
		
		private bool Equals(ITicket other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			return TicketID == other.TicketID && TicketTitle == other.TicketTitle && TicketNumber == other.TicketNumber && TicketPriority == other.TicketPriority &&
			       TicketImpact == other.TicketImpact && TicketStatus == other.TicketStatus && TicketSource == other.TicketSource && TicketType == other.TicketType && EndUserID == other.EndUserID &&
			       EndUserEmail == other.EndUserEmail && EndUserFirstName == other.EndUserFirstName && EndUserLastName == other.EndUserLastName && EndUserPhone == other.EndUserPhone &&
			       Nullable.Equals(TicketResolvedDate, other.TicketResolvedDate) && TicketCreatedDate.Equals(other.TicketCreatedDate) &&
			       Nullable.Equals(TechnicianFirstCommentDate, other.TechnicianFirstCommentDate) && Nullable.Equals(FirstResponseDueDate, other.FirstResponseDueDate) &&
			       Nullable.Equals(ClosedTicketDueDate, other.ClosedTicketDueDate) && FirstComment == other.FirstComment && LastEndUserComment == other.LastEndUserComment &&
			       Nullable.Equals(LastEndUserCommentTimestamp, other.LastEndUserCommentTimestamp) && LastTechnicianComment == other.LastTechnicianComment &&
			       Nullable.Equals(LastTechnicianCommentTimestamp, other.LastTechnicianCommentTimestamp) && OnSiteDurationSeconds == other.OnSiteDurationSeconds &&
			       OnSiteDurationMinutes == other.OnSiteDurationMinutes && OffSiteDurationSeconds == other.OffSiteDurationSeconds && OffSiteDurationMinutes == other.OffSiteDurationMinutes &&
			       OnSLADurationSeconds == other.OnSLADurationSeconds && OnSLADurationMinutes == other.OnSLADurationMinutes && OffSLADurationSeconds == other.OffSLADurationSeconds &&
			       OffSLADurationMinutes == other.OffSLADurationMinutes && TotalDurationSeconds == other.TotalDurationSeconds && TotalDurationMinutes == other.TotalDurationMinutes &&
			       CustomerID == other.CustomerID && CustomerName == other.CustomerName && CustomerBusinessNumber == other.CustomerBusinessNumber && TechnicianContactID == other.TechnicianContactID &&
			       TechnicianFullName == other.TechnicianFullName && TechnicianEmail == other.TechnicianEmail;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is ITicket other)) return false;
			return Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = TicketID;
				hashCode = (hashCode * 397) ^ (TicketTitle != null ? TicketTitle.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TicketNumber != null ? TicketNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TicketPriority != null ? TicketPriority.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TicketImpact != null ? TicketImpact.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TicketStatus != null ? TicketStatus.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TicketSource != null ? TicketSource.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TicketType != null ? TicketType.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ EndUserID;
				hashCode = (hashCode * 397) ^ (EndUserEmail != null ? EndUserEmail.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (EndUserFirstName != null ? EndUserFirstName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (EndUserLastName != null ? EndUserLastName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (EndUserPhone != null ? EndUserPhone.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ TicketResolvedDate.GetHashCode();
				hashCode = (hashCode * 397) ^ TicketCreatedDate.GetHashCode();
				hashCode = (hashCode * 397) ^ TechnicianFirstCommentDate.GetHashCode();
				hashCode = (hashCode * 397) ^ FirstResponseDueDate.GetHashCode();
				hashCode = (hashCode * 397) ^ ClosedTicketDueDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (FirstComment != null ? FirstComment.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LastEndUserComment != null ? LastEndUserComment.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ LastEndUserCommentTimestamp.GetHashCode();
				hashCode = (hashCode * 397) ^ (LastTechnicianComment != null ? LastTechnicianComment.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ LastTechnicianCommentTimestamp.GetHashCode();
				hashCode = (hashCode * 397) ^ OnSiteDurationSeconds.GetHashCode();
				hashCode = (hashCode * 397) ^ OnSiteDurationMinutes.GetHashCode();
				hashCode = (hashCode * 397) ^ OffSiteDurationSeconds.GetHashCode();
				hashCode = (hashCode * 397) ^ OffSiteDurationMinutes.GetHashCode();
				hashCode = (hashCode * 397) ^ OnSLADurationSeconds.GetHashCode();
				hashCode = (hashCode * 397) ^ OnSLADurationMinutes.GetHashCode();
				hashCode = (hashCode * 397) ^ OffSLADurationSeconds.GetHashCode();
				hashCode = (hashCode * 397) ^ OffSLADurationMinutes.GetHashCode();
				hashCode = (hashCode * 397) ^ TotalDurationSeconds.GetHashCode();
				hashCode = (hashCode * 397) ^ TotalDurationMinutes.GetHashCode();
				hashCode = (hashCode * 397) ^ CustomerID;
				hashCode = (hashCode * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (CustomerBusinessNumber != null ? CustomerBusinessNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ TechnicianContactID.GetHashCode();
				hashCode = (hashCode * 397) ^ (TechnicianFullName != null ? TechnicianFullName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TechnicianEmail != null ? TechnicianEmail.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
