using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Agent : IAgent
	{
		public int AgentID { get; set; }
		public string MachineID { get; set; }
		public string DeviceGuid { get; set; }
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
		public int? FolderID { get; set; }
		public string AgentName { get; set; }
		public string SystemName { get; set; }
		public string MachineName { get; set; }
		public string DomainName { get; set; }
		public string CurrentLoggedUsers { get; set; }
		public string ComputerDescription { get; set; }
		public bool Monitored { get; set; }
		public DateTime? LastPatchManagementReceived { get; set; }
		public string AgentVersion { get; set; }
		public bool Favorite { get; set; }
		public int? ThresholdID { get; set; }
		public int? MonitoredAgentID { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
		public bool Online { get; set; }
		public string ReportedFromIP { get; set; }
		public string AppViewUrl { get; set; }
		public string Motherboard { get; set; }
		public string Processor { get; set; }
		public int? Memory { get; set; }
		public string Display { get; set; }
		public string Sound { get; set; }
		public int? ProcessorCoresCount { get; set; }
		public string SystemDrive { get; set; }
		public string ProcessorClock { get; set; }
		public string Vendor { get; set; }
		public string VendorSerialNumber { get; set; }
		public string VendorBrandModel { get; set; }
		public string ProductName { get; set; }
		public string[] MacAddresses { get; set; }
		public string[] IpAddresses { get; set; }

		[JsonConverter(typeof(ConcreteArrayConverter<IHardwareDisk, HardwareDisk>))]
		public IHardwareDisk[] HardwareDisks { get; set; }
		
		public string OS { get; set; }
		public string OSType { get; set; }
		public string OSVersion { get; set; }
		public string OSBuild { get; set; }
		public string WindowsSerialNumber { get; set; }
		public string Office { get; set; }
		public string OfficeSP { get; set; }
		public bool? OfficeOEM { get; set; }
		public string OfficeSerialNumber { get; set; }
		public string OfficeFullVersion { get; set; }
		public string LastLoginUser { get; set; }
	}
}
