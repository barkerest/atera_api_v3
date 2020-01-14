namespace AteraAPI.V3.Enums
{
	/// <summary>
	/// The targets available for custom values.
	/// </summary>
	public enum CustomFieldTarget
	{
		/// <summary>
		/// Value belongs to a ticket.
		/// </summary>
		Ticket,
		
		/// <summary>
		/// Value belongs to a customer.
		/// </summary>
		Customer,
		
		/// <summary>
		/// Value belongs to a contact.
		/// </summary>
		Contact,
		
		/// <summary>
		/// Value belongs to a contract.
		/// </summary>
		Contract,
		
		/// <summary>
		/// Value belongs to a SLA.
		/// </summary>
		SLA,
		
		/// <summary>
		/// Value belongs to an agent.
		/// </summary>
		Agent,
		
		/// <summary>
		/// Value belongs to a SNMP device.
		/// </summary>
		SNMP,
		
		/// <summary>
		/// Value belongs to a TCP device.
		/// </summary>
		TCP,
		
		/// <summary>
		/// Value belongs to a HTTP device.
		/// </summary>
		HTTP,
		
		/// <summary>
		/// Value belongs to a generic device.
		/// </summary>
		Generic
	}
}
