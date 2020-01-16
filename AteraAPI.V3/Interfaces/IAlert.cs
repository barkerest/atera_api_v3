using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for alerts.
	/// </summary>
	public interface IAlert : IApiModel
	{
		/// <summary>
		/// The ID for the alert.
		/// </summary>
		int AlertID { get; }

		/// <summary>
		/// The code for the alert.
		/// </summary>
		int Code { get; set; }

		/// <summary>
		/// The source for the alert.
		/// </summary>
		string Source { get; set; }

		/// <summary>
		/// The alert title.
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// The alert severity.
		/// </summary>
		string Severity { get; set; }

		/// <summary>
		/// The date/time the alert was created.
		/// </summary>
		DateTime Created { get; }

		/// <summary>
		/// The date/time the snooze will end (if snoozed).
		/// </summary>
		DateTime? SnoozedEndDate { get; set; }

		/// <summary>
		/// The 1st value for the threshold.
		/// </summary>
		string ThresholdValue1 { get; set; }

		/// <summary>
		/// The 2nd value for the threshold.
		/// </summary>
		string ThresholdValue2 { get; set; }

		/// <summary>
		/// The 3rd value for the threshold.
		/// </summary>
		string ThresholdValue3 { get; set; }

		/// <summary>
		/// The 4th value for the threshold.
		/// </summary>
		string ThresholdValue4 { get; set; }

		/// <summary>
		/// The 5th value for the threshold.
		/// </summary>
		string ThresholdValue5 { get; set; }

		/// <summary>
		/// The GUID for the device that generated the alert.
		/// </summary>
		string    DeviceGuid         { get; set; }
		
		/// <summary>
		/// Any additional information.
		/// </summary>
		string    AdditionalInfo     { get; set; }
		
		/// <summary>
		/// The category for the alert.
		/// </summary>
		string AlertCategoryID { get; set; }

		/// <summary>
		/// Was the alert archived?
		/// </summary>
		bool      Archived           { get; }
		
		/// <summary>
		/// The date/time the alert was archived.
		/// </summary>
		DateTime? ArchivedDate       { get; }
		
		/// <summary>
		/// The ticket created for this alert.
		/// </summary>
		int?      TicketID           { get; set; }
		
		/// <summary>
		/// The alert message.
		/// </summary>
		string    AlertMessage       { get; set; }
		
		/// <summary>
		/// The device name attached to this alert.
		/// </summary>
		string    DeviceName         { get; set; }
		
		/// <summary>
		/// The customer attached to this alert.
		/// </summary>
		int       CustomerID         { get; set; }
		
		/// <summary>
		/// The customer attached to this alert.
		/// </summary>
		string    CustomerName       { get; }
		
		/// <summary>
		/// The message template for the alert.
		/// </summary>
		string    MessageTemplate    { get; set; }
		
		/// <summary>
		/// The folder for the device attached to this alert.
		/// </summary>
		int?      FolderID           { get; set; }
		
		/// <summary>
		/// Number of polling cycles this alert has been active.
		/// </summary>
		int?      PollingCyclesCount { get; }
	}
}
