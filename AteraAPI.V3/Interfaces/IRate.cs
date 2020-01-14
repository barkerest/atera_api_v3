namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for rates.
	/// </summary>
	public interface IRate
	{
		/// <summary>
		/// The ID for this rate.
		/// </summary>
		int RateID { get; }
		
		/// <summary>
		/// The amount for this rate.
		/// </summary>
		double Amount { get; set; }
		
		/// <summary>
		/// The description of this rate.
		/// </summary>
		string Description { get; set; }
		
		/// <summary>
		/// The SKU for this rate.
		/// </summary>
		string SKU { get; set; }
		
		/// <summary>
		/// The category for this rate.
		/// </summary>
		string Category { get; set; }
		
		/// <summary>
		/// Is this rate archived?
		/// </summary>
		/// <remarks>
		/// Does not appear in the JSON from the service, no idea how to read.
		/// </remarks>
		bool? Archived { get; set; }
	}
}
