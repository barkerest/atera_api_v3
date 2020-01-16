using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for work hour records.
	/// </summary>
	public interface IWorkHourRecord : IApiModel
	{
		/// <summary>
		/// The ticket ID.
		/// </summary>
		int TicketID { get; }
		
		/// <summary>
		/// The work hour ID.
		/// </summary>
		int WorkHoursID { get; }
		
		/// <summary>
		/// The start of the record.
		/// </summary>
		DateTime StartWorkHour { get; }
		
		/// <summary>
		/// The end of the record.
		/// </summary>
		DateTime EndWorkHour { get; }
		
		/// <summary>
		/// The technician ID.
		/// </summary>
		int TechnicianContactID { get; }
		
		/// <summary>
		/// Is this record billable.
		/// </summary>
		bool Billable { get; }
		
		/// <summary>
		/// Is this record on-site.
		/// </summary>
		bool OnCustomerSite { get; }
		
		/// <summary>
		/// The description added to the record.
		/// </summary>
		string Description { get; }
		
		/// <summary>
		/// The technician name.
		/// </summary>
		string TechnicianFullName { get; }
		
		/// <summary>
		/// The technician email.
		/// </summary>
		string TechnicianEmail { get; }
	}
}
