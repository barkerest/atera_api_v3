using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Contact : IContact
	{
		[JsonProperty("EndUserID")]
		public int ContactID { get; set; }
		public bool ShouldSerializeContactID() => false;
		
		public int CustomerID { get; set; }
		public bool ShouldSerializeCustomerID() => (ContactID == 0);
		
		public string CustomerName { get; set; }
		public bool ShouldSerializeCustomerName() => (ContactID == 0);
		
		[JsonProperty("Firstname")]
		public string FirstName { get; set; }
		
		[JsonProperty("Lastname")]
		public string LastName { get; set; }
		
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
	}
}
