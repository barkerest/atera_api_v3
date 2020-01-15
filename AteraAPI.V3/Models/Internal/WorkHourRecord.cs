using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class WorkHourRecord : IWorkHourRecord
	{
		public int TicketID { get; set; }
		public int WorkHoursID { get; set; }
		public DateTime StartWorkHour { get; set; }
		public DateTime EndWorkHour { get; set; }
		public int TechnicianContactID { get; set; }
		public bool Billable { get; set; }
		public bool OnCustomerSite { get; set; }
		public string Description { get; set; }
		public string TechnicianFullName { get; set; }
		public string TechnicianEmail { get; set; }
	}
}
