using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Contact : IContact
	{
		[JsonProperty("EndUserID")] public int ContactID { get; set; }
		public bool ShouldSerializeContactID() => false;

		public int CustomerID { get; set; }
		public bool ShouldSerializeCustomerID() => (ContactID == 0);

		public string CustomerName { get; set; }
		public bool ShouldSerializeCustomerName() => (ContactID == 0);

		[JsonProperty("Firstname")] public string FirstName { get; set; }

		[JsonProperty("Lastname")] public string LastName { get; set; }

		public string JobTitle { get; set; }

		public string Email { get; set; }
		public bool ShouldSerializeEmail() => (ContactID == 0);

		public string Phone { get; set; }

		public bool IsContactPerson { get; set; }

		public bool InIgnoreMode { get; set; }

		public DateTime CreatedOn { get; set; }
		public bool ShouldSerializeCreatedOn() => false;

		public DateTime LastModified { get; set; }
		public bool ShouldSerializeLastModified() => false;

		public override string ToString()
		{
			return $"{CustomerName}: {FirstName} {LastName}";
		}

		private bool Equals(IContact other)
		{
			return ContactID == other.ContactID && CustomerID == other.CustomerID && CustomerName == other.CustomerName && FirstName == other.FirstName && LastName == other.LastName &&
			       JobTitle == other.JobTitle && Email == other.Email && Phone == other.Phone && IsContactPerson == other.IsContactPerson && InIgnoreMode == other.InIgnoreMode &&
			       CreatedOn.Equals(other.CreatedOn) && LastModified.Equals(other.LastModified);
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContact other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = ContactID;
				hashCode = (hashCode * 397) ^ CustomerID;
				hashCode = (hashCode * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (JobTitle != null ? JobTitle.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ IsContactPerson.GetHashCode();
				hashCode = (hashCode * 397) ^ InIgnoreMode.GetHashCode();
				hashCode = (hashCode * 397) ^ CreatedOn.GetHashCode();
				hashCode = (hashCode * 397) ^ LastModified.GetHashCode();
				return hashCode;
			}
		}
	}
}
