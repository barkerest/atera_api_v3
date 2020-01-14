namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Details about a project hourly rate contract.
	/// </summary>
	public interface IContractProjectHourlyDetails
	{
		/// <summary>
		/// The hourly rate.
		/// </summary>
		IRate PrimaryRate { get; }
		
		/// <summary>
		/// Additional rates.
		/// </summary>
		IRate[] AdditionalRates { get; }
	}
}
