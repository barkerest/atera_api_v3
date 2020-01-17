using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Customer : ICustomer
	{
		public int CustomerID { get; set; }

		public bool ShouldSerializeCustomerID() => false;

		public string CustomerName { get; set; }

		public string BusinessNumber { get; set; }

		public string Domain { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string Country { get; set; }

		[JsonProperty("ZipCodeStr")] public string ZipCode { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Notes { get; set; }

		public string Logo { get; set; }

		[JsonProperty("Links")] public string Website { get; set; }

		public double? Longitude { get; set; }

		public double? Latitude { get; set; }

		public DateTime CreatedOn { get; set; }

		public bool ShouldSerializeCreatedOn() => false;

		public DateTime LastModified { get; set; }

		public bool ShouldSerializeLastModified() => false;

		public override string ToString()
		{
			return CustomerName;
		}

		private bool Equals(ICustomer other)
		{
			return CustomerID == other.CustomerID && CustomerName == other.CustomerName && BusinessNumber == other.BusinessNumber && Domain == other.Domain && Address == other.Address &&
			       City == other.City && State == other.State && Country == other.Country && ZipCode == other.ZipCode && Phone == other.Phone && Fax == other.Fax && Notes == other.Notes &&
			       Logo == other.Logo && Website == other.Website && Nullable.Equals(Longitude, other.Longitude) && Nullable.Equals(Latitude, other.Latitude) && CreatedOn.Equals(other.CreatedOn) &&
			       LastModified.Equals(other.LastModified);
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is ICustomer other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = CustomerID;
				hashCode = (hashCode * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BusinessNumber != null ? BusinessNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Domain != null ? Domain.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ZipCode != null ? ZipCode.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Fax != null ? Fax.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Notes != null ? Notes.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Logo != null ? Logo.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Website != null ? Website.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
				hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
				hashCode = (hashCode * 397) ^ CreatedOn.GetHashCode();
				hashCode = (hashCode * 397) ^ LastModified.GetHashCode();
				return hashCode;
			}
		}
	}
}
