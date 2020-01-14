using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class InvoiceContact : IInvoiceContact
	{
		public string CompanyName { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactLastName { get; set; }
		public string ContactFullName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}
