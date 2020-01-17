using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class Alert : IAlert
	{
		public int AlertID { get; set; }
		public bool ShouldSerializeAlertID() => false;

		public int    Code     { get; set; }
		public string Source   { get; set; }
		public string Title    { get; set; }
		public string Severity { get; set; }

		public DateTime Created { get; set; }
		public bool ShouldSerializeCreated() => false;

		public DateTime? SnoozedEndDate  { get; set; }
		public string    ThresholdValue1 { get; set; }
		public string    ThresholdValue2 { get; set; }
		public string    ThresholdValue3 { get; set; }
		public string    ThresholdValue4 { get; set; }
		public string    ThresholdValue5 { get; set; }
		public string    DeviceGuid      { get; set; }
		public string    AdditionalInfo  { get; set; }
		public string    AlertCategoryID { get; set; }

		public bool Archived { get; set; }
		public bool ShouldSerializeArchived() => false;

		public DateTime? ArchivedDate { get; set; }
		public bool ShouldSerializeArchivedDate() => false;

		public int?   TicketID     { get; set; }
		public string AlertMessage { get; set; }
		public string DeviceName   { get; set; }
		public int    CustomerID   { get; set; }

		public string CustomerName { get; set; }
		public bool ShouldSerializeCustomerName() => false;

		public string MessageTemplate { get; set; }
		public int?   FolderID        { get; set; }

		public int? PollingCyclesCount { get; set; }
		public bool ShouldSerializePollingCyclesCount() => false;

		public override string ToString()
		{
			return Title;
		}


		private bool Equals(IAlert other)
		{
			return AlertID == other.AlertID && Code == other.Code && Source == other.Source && Title == other.Title && Severity == other.Severity && Created.Equals(other.Created) &&
			       Nullable.Equals(SnoozedEndDate, other.SnoozedEndDate) && ThresholdValue1 == other.ThresholdValue1 && ThresholdValue2 == other.ThresholdValue2 &&
			       ThresholdValue3 == other.ThresholdValue3 && ThresholdValue4 == other.ThresholdValue4 && ThresholdValue5 == other.ThresholdValue5 && DeviceGuid == other.DeviceGuid &&
			       AdditionalInfo == other.AdditionalInfo && AlertCategoryID == other.AlertCategoryID && Archived == other.Archived && Nullable.Equals(ArchivedDate, other.ArchivedDate) &&
			       TicketID == other.TicketID && AlertMessage == other.AlertMessage && DeviceName == other.DeviceName && CustomerID == other.CustomerID && CustomerName == other.CustomerName &&
			       MessageTemplate == other.MessageTemplate && FolderID == other.FolderID && PollingCyclesCount == other.PollingCyclesCount;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IAlert other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = AlertID;
				hashCode = (hashCode * 397) ^ Code;
				hashCode = (hashCode * 397) ^ (Source != null ? Source.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Severity != null ? Severity.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Created.GetHashCode();
				hashCode = (hashCode * 397) ^ SnoozedEndDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (ThresholdValue1 != null ? ThresholdValue1.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ThresholdValue2 != null ? ThresholdValue2.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ThresholdValue3 != null ? ThresholdValue3.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ThresholdValue4 != null ? ThresholdValue4.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ThresholdValue5 != null ? ThresholdValue5.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (DeviceGuid != null ? DeviceGuid.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (AdditionalInfo != null ? AdditionalInfo.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (AlertCategoryID != null ? AlertCategoryID.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Archived.GetHashCode();
				hashCode = (hashCode * 397) ^ ArchivedDate.GetHashCode();
				hashCode = (hashCode * 397) ^ TicketID.GetHashCode();
				hashCode = (hashCode * 397) ^ (AlertMessage != null ? AlertMessage.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (DeviceName != null ? DeviceName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ CustomerID;
				hashCode = (hashCode * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (MessageTemplate != null ? MessageTemplate.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ FolderID.GetHashCode();
				hashCode = (hashCode * 397) ^ PollingCyclesCount.GetHashCode();
				return hashCode;
			}
		}
	}
}
