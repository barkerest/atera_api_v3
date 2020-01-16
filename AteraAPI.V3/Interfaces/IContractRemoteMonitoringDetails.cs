namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details for a remote monitoring contract.
	/// </summary>
	public interface IContractRemoteMonitoringDetails : IApiModel
	{
		/// <summary>
		/// Rate per device.
		/// </summary>
		IRate RatePerDevice { get; }
		
		/// <summary>
		/// How are devices counted.
		/// </summary>
		string CountBy { get; }
		
		/// <summary>
		/// How often are invoices generated.
		/// </summary>
		string BillingPeriod { get; }
	}
}
