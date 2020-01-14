namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details for an hour block contract.
	/// </summary>
	public interface IContractHourBlockDetails
	{
		/// <summary>
		/// Number of hours included.
		/// </summary>
		double HoursIncluded { get; }
		
		/// <summary>
		/// The hourly rate.
		/// </summary>
		IRate PricePerHour { get; }
		
		/// <summary>
		/// The overage rate.
		/// </summary>
		IRate OverageRate { get; }
		
		/// <summary>
		/// Should remaining balance roll over into next billing period.
		/// </summary>
		bool CommitRollover { get; }
		
		/// <summary>
		/// The billing period.
		/// </summary>
		string BillingPeriod { get; }
	}
}
