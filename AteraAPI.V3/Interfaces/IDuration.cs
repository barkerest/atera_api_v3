namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines a duration.
	/// </summary>
	public interface IDuration
	{
		/// <summary>
		/// The ticket ID.
		/// </summary>
		int TicketID { get; }
		
		/// <summary>
		/// Hours outside the SLA.
		/// </summary>
		double OffSLADurationHours { get; }
		
		/// <summary>
		/// Hours off-site.
		/// </summary>
		double OffSiteDurationHours { get; }
		
		/// <summary>
		/// Hours in the SLA.
		/// </summary>
		double OnSLADurationHours { get; }
		
		/// <summary>
		/// Hours on-site.
		/// </summary>
		double OnSiteDurationHours { get; }
		
		/// <summary>
		/// Total billable hours.
		/// </summary>
		double TotalDurationHours { get; }
				
	}
}
