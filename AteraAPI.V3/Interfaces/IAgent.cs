using System;

namespace AteraAPI.V3.Interfaces
{
	public interface IAgent
	{
		/// <summary>
		/// The agent ID.
		/// </summary>
		int AgentID { get; }
		
		/// <summary>
		/// A machine ID (may be null).
		/// </summary>
		string MachineID { get; }
		
		/// <summary>
		/// The GUID assigned to this device.
		/// </summary>
		string DeviceGuid { get; }
		
		/// <summary>
		/// The customer this agent belongs to.
		/// </summary>
		int CustomerID { get; }
		
		/// <summary>
		/// The customer this agent belongs to.
		/// </summary>
		string CustomerName { get; }
		
		/// <summary>
		/// The folder this agent is stored within under the customer.
		/// </summary>
		int? FolderID { get; }
		
		/// <summary>
		/// The agent name.
		/// </summary>
		string AgentName { get; }
		
		/// <summary>
		/// The system name.
		/// </summary>
		string SystemName { get; }
		
		/// <summary>
		/// The machine name.
		/// </summary>
		string MachineName { get; }
		
		/// <summary>
		/// The domain name.
		/// </summary>
		string DomainName { get; }
		
		/// <summary>
		/// The user(s) currently logged into the computer.
		/// </summary>
		string CurrentLoggedUsers { get; }
		
		/// <summary>
		/// The computer description.
		/// </summary>
		string ComputerDescription { get; }
		
		/// <summary>
		/// Is this agent monitored?
		/// </summary>
		bool Monitored { get; }
		
		/// <summary>
		/// The date/time that patch management was last handled by the agent.
		/// </summary>
		DateTime? LastPatchManagementReceived { get; }
		
		/// <summary>
		/// The version of the agent running on the computer.
		/// </summary>
		string AgentVersion { get; }
		
		/// <summary>
		/// Is this agent a favorite?
		/// </summary>
		bool Favorite { get; }
		
		/// <summary>
		/// The thresholds to use for this agent.
		/// </summary>
		int? ThresholdID { get; }
		
		/// <summary>
		/// The agent monitoring this agent.
		/// </summary>
		int? MonitoredAgentID { get; }
		
		/// <summary>
		/// The date/time the agent was created.
		/// </summary>
		DateTime Created { get; }
		
		/// <summary>
		/// The date/time the agent was last modified.
		/// </summary>
		DateTime Modified { get; }
		
		/// <summary>
		/// Is the agent online?
		/// </summary>
		bool Online { get; }
		
		/// <summary>
		/// The IP address the agent last reported from.
		/// </summary>
		string ReportedFromIP { get; }
		
		/// <summary>
		/// The URL to open up this agent in a browser.
		/// </summary>
		string AppViewUrl { get; }
		
		/// <summary>
		/// The motherboard details for the computer.
		/// </summary>
		string Motherboard { get; }
		
		/// <summary>
		/// The processor details for the computer.
		/// </summary>
		string Processor { get; }
		
		/// <summary>
		/// The memory size (in MB) for the computer.
		/// </summary>
		int? Memory { get; }
		
		/// <summary>
		/// Information about the display adapter for the computer.
		/// </summary>
		string Display { get; }
		
		/// <summary>
		/// Information about the sound card for the computer.
		/// </summary>
		string Sound { get; }
		
		/// <summary>
		/// The number of processor cores for the computer.
		/// </summary>
		int? ProcessorCoresCount { get; }
		
		/// <summary>
		/// The system drive letter for the computer.
		/// </summary>
		string SystemDrive { get; }
		
		/// <summary>
		/// The processor speed (in GHz)
		/// </summary>
		string ProcessorClock { get; }
		
		/// <summary>
		/// The vendor of the computer.
		/// </summary>
		string Vendor { get; }
		
		/// <summary>
		/// The serial number of the computer.
		/// </summary>
		string VendorSerialNumber { get; }
		
		/// <summary>
		/// The model of the computer.
		/// </summary>
		string VendorBrandModel { get; }
		
		/// <summary>
		/// The product name for the device.
		/// </summary>
		string ProductName { get; }
		
		/// <summary>
		/// The MAC addresses for the device.
		/// </summary>
		string[] MacAddresses { get; }
		
		/// <summary>
		/// The IP addresses for the device.
		/// </summary>
		string[] IpAddresses { get; }
		
		/// <summary>
		/// The disk drives in the computer.
		/// </summary>
		IHardwareDisk[] HardwareDisks { get; }
		
		/// <summary>
		/// The OS for the device.
		/// </summary>
		string OS { get; }
		
		/// <summary>
		/// The type of OS.
		/// </summary>
		string OSType { get; }
		
		/// <summary>
		/// The OS version on the computer.
		/// </summary>
		string OSVersion { get; }
		
		/// <summary>
		/// The OS build on the computer.
		/// </summary>
		string OSBuild { get; }
		
		/// <summary>
		/// The windows product key used by the computer.
		/// </summary>
		string WindowsSerialNumber { get; }
		
		/// <summary>
		/// The version of Office installed on the computer.
		/// </summary>
		string Office { get; }
		
		/// <summary>
		/// The Office service pack installed on the computer.
		/// </summary>
		string OfficeSP { get; }
		
		/// <summary>
		/// Is the Office version installed using an OEM license?
		/// </summary>
		bool? OfficeOEM { get; }
		
		/// <summary>
		/// The Office (partial) product key used by the computer.
		/// </summary>
		string OfficeSerialNumber { get; }
		
		/// <summary>
		/// The full version of Office installed on the computer.
		/// </summary>
		string OfficeFullVersion { get; }
		
		/// <summary>
		/// The last user to log into the computer.
		/// </summary>
		string LastLoginUser { get; }
	}
}
