using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models
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

		[JsonProperty("ZipCodeStr")]
		public string ZipCode { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Notes { get; set; }

		public string Logo { get; set; }

		[JsonProperty("Links")]
		public string Website { get; set; }

		public double? Longitude { get; set; }

		public double? Latitude { get; set; }

		public DateTime CreatedOn { get; set; }

		public bool ShouldSerializeCreatedOn() => false;

		public DateTime LastModified { get; set; }

		public bool ShouldSerializeLastModified() => false;
	}
}
