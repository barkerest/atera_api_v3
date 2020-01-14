using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class Alert : IAlert
	{
		public int AlertID { get; set; }
		public bool ShouldSerializeAlertID() => false;
		
		public int Code { get; set; }
		public string Source { get; set; }
		public string Title { get; set; }
		public string Severity { get; set; }
		
		public DateTime Created { get; set; }
		public bool ShouldSerializeCreated() => false;
		
		public DateTime? SnoozedEndDate { get; set; }
		public string ThresholdValue1 { get; set; }
		public string ThresholdValue2 { get; set; }
		public string ThresholdValue3 { get; set; }
		public string ThresholdValue4 { get; set; }
		public string ThresholdValue5 { get; set; }
		public string DeviceGuid { get; set; }
		public string AdditionalInfo { get; set; }
		public string AlertCategoryID { get; set; }
		
		public bool Archived { get; set; }
		public bool ShouldSerializeArchived() => false;
		
		public DateTime? ArchivedDate { get; set; }
		public bool ShouldSerializeArchivedDate() => false;
		
		public int? TicketID { get; set; }
		public string AlertMessage { get; set; }
		public string DeviceName { get; set; }
		public int CustomerID { get; set; }
		
		public string CustomerName { get; set; }
		public bool ShouldSerializeCustomerName() => false;
		
		public string MessageTemplate { get; set; }
		public int? FolderID { get; set; }
		
		public int? PollingCyclesCount { get; set; }
		public bool ShouldSerializePollingCyclesCount() => false;
	}
}
