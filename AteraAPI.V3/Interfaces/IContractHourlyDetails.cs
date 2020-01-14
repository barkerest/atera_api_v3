namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details for an hourly contract.
	/// </summary>
	public interface IContractHourlyDetails
	{
		/// <summary>
		/// The hourly rate.
		/// </summary>
		IRate PrimaryRate { get; }
		
		/// <summary>
		/// Additional rates.
		/// </summary>
		IRate[] AdditionalRates { get; }
		
		/// <summary>
		/// How often are invoices generated.
		/// </summary>
		string BillingPeriod { get; }
	}
}
