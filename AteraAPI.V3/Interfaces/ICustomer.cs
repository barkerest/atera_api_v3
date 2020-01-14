using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for customers.
	/// </summary>
	public interface ICustomer
	{
		/// <summary>
		/// The ID of the customer.
		/// </summary>
		int CustomerID { get; }
		
		/// <summary>
		/// The name of the customer.
		/// </summary>
		string CustomerName { get; set; }
		
		/// <summary>
		/// The tax number for this business.
		/// </summary>
		string BusinessNumber { get; set; }
		
		/// <summary>
		/// The domain for this business.
		/// </summary>
		/// <remarks>
		/// Used to assign incoming email to this business.
		/// </remarks>
		string Domain { get; set; }
		
		/// <summary>
		/// The street address.
		/// </summary>
		string Address { get; set; }
		
		/// <summary>
		/// The city.
		/// </summary>
		string City { get; set; }
		
		/// <summary>
		/// The state or province.
		/// </summary>
		string State { get; set; }
		
		/// <summary>
		/// The country.
		/// </summary>
		string Country { get; set; }
		
		/// <summary>
		/// The postal code.
		/// </summary>
		string ZipCode { get; set; }
		
		/// <summary>
		/// The primary phone number.
		/// </summary>
		string Phone { get; set; }
		
		/// <summary>
		/// The primary fax number.
		/// </summary>
		string Fax { get; set; }
		
		/// <summary>
		/// General notes about the customer.
		/// </summary>
		string Notes { get; set; }
		
		/// <summary>
		/// URL for the customer's logo.
		/// </summary>
		string Logo { get; set; }
		
		/// <summary>
		/// The website link for the customer.
		/// </summary>
		string Website { get; set; }
		
		/// <summary>
		/// The longitude for the customer address.
		/// </summary>
		double? Longitude { get; set; }
		
		/// <summary>
		/// The latitude for the customer address.
		/// </summary>
		double? Latitude { get; set; }
		
		/// <summary>
		/// Date/time the customer was created.
		/// </summary>
		DateTime CreatedOn { get; }
		
		/// <summary>
		/// Date/time the customer was last modified.
		/// </summary>
		DateTime LastModified { get; }
	}
	
}
