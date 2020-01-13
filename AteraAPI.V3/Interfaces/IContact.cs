using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for contacts.
	/// </summary>
	public interface IContact
	{
		/// <summary>
		/// The contact ID.
		/// </summary>
		int ContactID { get; }
		
		/// <summary>
		/// The customer the contact belongs to.
		/// </summary>
		/// <remarks>
		/// Not changeable during update.
		/// During creation if CustomerID -or- CustomerName is present, that value will be used to set the customer for the new contact.
		/// </remarks>
		int CustomerID { get; set; }
		
		/// <summary>
		/// The name of the customer the contact belongs to.
		/// </summary>
		/// <remarks>
		/// Not changeable during update.
		/// During creation if CustomerID -or- CustomerName is present, that value will be used to set the customer for the new contact.
		/// </remarks>
		string CustomerName { get; set; }
		
		/// <summary>
		/// The first name of the contact.
		/// </summary>
		string FirstName { get; set; }
		
		/// <summary>
		/// The last name of the contact.
		/// </summary>
		string LastName { get; set; }
		
		/// <summary>
		/// The job title for the contact.
		/// </summary>
		string JobTitle { get; set; }
		
		/// <summary>
		/// The email for the contact (must be valid).
		/// </summary>
		/// <remarks>
		/// Not changeable during update.
		/// </remarks>
		string Email { get; set; }
		
		/// <summary>
		/// The phone number for the contact.
		/// </summary>
		string Phone { get; set; }
		
		/// <summary>
		/// Is this the main contact for the customer.
		/// </summary>
		bool IsContactPerson { get; set; }
		
		/// <summary>
		/// Are emails from this contact ignored for ticket creation.
		/// </summary>
		bool InIgnoreMode { get; set; }
		
		/// <summary>
		/// The date/time the contact was created.
		/// </summary>
		DateTime CreatedOn { get; }
		
		/// <summary>
		/// The date/time the contact was last modified.
		/// </summary>
		DateTime LastModified { get; }
	}
}
