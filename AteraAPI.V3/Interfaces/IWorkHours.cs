namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for work hours.
	/// </summary>
	public interface IWorkHours
	{
		/// <summary>
		/// The ticket ID.
		/// </summary>
		int TicketID { get; }
		
		/// <summary>
		/// The billable duration.
		/// </summary>
		IDuration Billable { get; }
		
		/// <summary>
		/// The non-billable duration.
		/// </summary>
		IDuration NonBillable { get; }
	}
}
