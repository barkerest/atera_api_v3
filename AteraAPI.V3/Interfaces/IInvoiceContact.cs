namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines an invoice contact.
	/// </summary>
	public interface IInvoiceContact : IApiModel
	{
		/// <summary>
		/// The name of the company.
		/// </summary>
		string CompanyName { get; }
		
		/// <summary>
		/// The first name of the contact.
		/// </summary>
		string ContactFirstName { get; }
		
		/// <summary>
		/// The last name of the contact.
		/// </summary>
		string ContactLastName { get; }
		
		/// <summary>
		/// The full name of the contact.
		/// </summary>
		string ContactFullName { get; }
		
		/// <summary>
		/// The address of the contact.
		/// </summary>
		string Address { get; }
		
		/// <summary>
		/// The city of the contact.
		/// </summary>
		string City { get; }
		
		/// <summary>
		/// The state of the contact.
		/// </summary>
		string State { get; }
		
		/// <summary>
		/// The zip code of the contact.
		/// </summary>
		string ZipCode { get; }
		
		/// <summary>
		/// The country of the contact.
		/// </summary>
		string Country { get; }
		
		/// <summary>
		/// The phone number of the contact.
		/// </summary>
		string Phone { get; }
		
		/// <summary>
		/// The email address of the contact.
		/// </summary>
		string Email { get; }
	}
}
