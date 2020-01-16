namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details about a one-time-fee contract.
	/// </summary>
	public interface IContractOneTimeFeeDetails : IApiModel
	{
		/// <summary>
		/// The amount of the contract.
		/// </summary>
		IRate TotalAmount { get; }
	}
}
