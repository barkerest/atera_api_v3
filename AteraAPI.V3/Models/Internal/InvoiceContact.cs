using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class InvoiceContact : IInvoiceContact
	{
		public string CompanyName      { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactLastName  { get; set; }
		public string ContactFullName  { get; set; }
		public string Address          { get; set; }
		public string City             { get; set; }
		public string State            { get; set; }
		public string ZipCode          { get; set; }
		public string Country          { get; set; }
		public string Phone            { get; set; }
		public string Email            { get; set; }

		public override string ToString()
		{
			return $"{CompanyName}: {ContactFullName}";
		}

		private bool Equals(IInvoiceContact other)
		{
			return CompanyName == other.CompanyName && ContactFirstName == other.ContactFirstName && ContactLastName == other.ContactLastName && ContactFullName == other.ContactFullName &&
			       Address == other.Address && City == other.City && State == other.State && ZipCode == other.ZipCode && Country == other.Country && Phone == other.Phone && Email == other.Email;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IInvoiceContact other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (CompanyName != null ? CompanyName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ContactFirstName != null ? ContactFirstName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ContactLastName != null ? ContactLastName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ContactFullName != null ? ContactFullName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ZipCode != null ? ZipCode.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
