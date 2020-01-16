namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details for a retainer contract.
	/// </summary>
	public interface IContractRetainerDetails : IApiModel
	{
		/// <summary>
		/// Quantity on retainer.
		/// </summary>
		int Quantity { get; }
		
		/// <summary>
		/// The rate.
		/// </summary>
		IRate Rate { get; }
		
		/// <summary>
		/// The billing period.
		/// </summary>
		string BillingPeriod { get; }
	}
}
