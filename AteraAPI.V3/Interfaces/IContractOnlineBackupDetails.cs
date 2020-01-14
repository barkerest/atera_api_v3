namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details for an online backup contract.
	/// </summary>
	public interface IContractOnlineBackupDetails
	{
		/// <summary>
		/// Rate per GB.
		/// </summary>
		IRate RatePerGB { get; }
		
		/// <summary>
		/// How are units counted.
		/// </summary>
		string CountBy { get; }
		
		/// <summary>
		/// How often are invoices generated.
		/// </summary>
		string BillingPeriod { get; }
	}
}
