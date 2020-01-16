using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class WorkHourRecord : IWorkHourRecord
	{
		public int      TicketID            { get; set; }
		public int      WorkHoursID         { get; set; }
		public DateTime StartWorkHour       { get; set; }
		public DateTime EndWorkHour         { get; set; }
		public int      TechnicianContactID { get; set; }
		public bool     Billable            { get; set; }
		public bool     OnCustomerSite      { get; set; }
		public string   Description         { get; set; }
		public string   TechnicianFullName  { get; set; }
		public string   TechnicianEmail     { get; set; }

		public override string ToString()
		{
			var non = Billable ? "" : "Non-";
			return $"{TechnicianFullName}: {non}Billable {EndWorkHour.Subtract(StartWorkHour).TotalHours:0.00} hours";
		}

		private bool Equals(IWorkHourRecord other)
		{
			return TicketID == other.TicketID && WorkHoursID == other.WorkHoursID && StartWorkHour.Equals(other.StartWorkHour) && EndWorkHour.Equals(other.EndWorkHour) &&
			       TechnicianContactID == other.TechnicianContactID && Billable == other.Billable && OnCustomerSite == other.OnCustomerSite && Description == other.Description &&
			       TechnicianFullName == other.TechnicianFullName && TechnicianEmail == other.TechnicianEmail;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is IWorkHourRecord other)) return false;
			return Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = TicketID;
				hashCode = (hashCode * 397) ^ WorkHoursID;
				hashCode = (hashCode * 397) ^ StartWorkHour.GetHashCode();
				hashCode = (hashCode * 397) ^ EndWorkHour.GetHashCode();
				hashCode = (hashCode * 397) ^ TechnicianContactID;
				hashCode = (hashCode * 397) ^ Billable.GetHashCode();
				hashCode = (hashCode * 397) ^ OnCustomerSite.GetHashCode();
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TechnicianFullName != null ? TechnicianFullName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TechnicianEmail != null ? TechnicianEmail.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
