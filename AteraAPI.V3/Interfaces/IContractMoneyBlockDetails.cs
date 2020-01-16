namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details for a money block contract.
	/// </summary>
	public interface IContractMoneyBlockDetails : IApiModel
	{
		/// <summary>
		/// The contract amount.
		/// </summary>
		IRate ContractAmount { get; }
		
		/// <summary>
		/// The hourly rate.
		/// </summary>
		IRate PrimaryRate { get; }
		
		/// <summary>
		/// Additional rates.
		/// </summary>
		IRate[] AdditionalRates { get; }
		
		/// <summary>
		/// Does remaining balance roll over into next period. 
		/// </summary>
		bool CommitRollover { get; }
		
		/// <summary>
		/// The billing period.
		/// </summary>
		string BillingPeriod { get; }
	}
}
