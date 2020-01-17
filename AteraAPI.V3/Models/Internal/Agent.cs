using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Agent : IAgent
	{
		public int       AgentID                     { get; set; }
		public string    MachineID                   { get; set; }
		public string    DeviceGuid                  { get; set; }
		public int       CustomerID                  { get; set; }
		public string    CustomerName                { get; set; }
		public int?      FolderID                    { get; set; }
		public string    AgentName                   { get; set; }
		public string    SystemName                  { get; set; }
		public string    MachineName                 { get; set; }
		public string    DomainName                  { get; set; }
		public string    CurrentLoggedUsers          { get; set; }
		public string    ComputerDescription         { get; set; }
		public bool      Monitored                   { get; set; }
		public DateTime? LastPatchManagementReceived { get; set; }
		public string    AgentVersion                { get; set; }
		public bool      Favorite                    { get; set; }
		public int?      ThresholdID                 { get; set; }
		public int?      MonitoredAgentID            { get; set; }
		public DateTime  Created                     { get; set; }
		public DateTime  Modified                    { get; set; }
		public bool      Online                      { get; set; }
		public string    ReportedFromIP              { get; set; }
		public string    AppViewUrl                  { get; set; }
		public string    Motherboard                 { get; set; }
		public string    Processor                   { get; set; }
		public int?      Memory                      { get; set; }
		public string    Display                     { get; set; }
		public string    Sound                       { get; set; }
		public int?      ProcessorCoresCount         { get; set; }
		public string    SystemDrive                 { get; set; }
		public string    ProcessorClock              { get; set; }
		public string    Vendor                      { get; set; }
		public string    VendorSerialNumber          { get; set; }
		public string    VendorBrandModel            { get; set; }
		public string    ProductName                 { get; set; }
		public string[]  MacAddresses                { get; set; }
		public string[]  IpAddresses                 { get; set; }

		[JsonConverter(typeof(ConcreteArrayConverter<IHardwareDisk, HardwareDisk>))]
		public IHardwareDisk[] HardwareDisks { get; set; }

		public string OS                  { get; set; }
		public string OSType              { get; set; }
		public string OSVersion           { get; set; }
		public string OSBuild             { get; set; }
		public string WindowsSerialNumber { get; set; }
		public string Office              { get; set; }
		public string OfficeSP            { get; set; }
		public bool?  OfficeOEM           { get; set; }
		public string OfficeSerialNumber  { get; set; }
		public string OfficeFullVersion   { get; set; }
		public string LastLoginUser       { get; set; }

		public override string ToString()
		{
			return AgentName;
		}

		private bool Equals(IAgent other)
		{
			return AgentID == other.AgentID && MachineID == other.MachineID && DeviceGuid == other.DeviceGuid && CustomerID == other.CustomerID && CustomerName == other.CustomerName &&
			       FolderID == other.FolderID && AgentName == other.AgentName && SystemName == other.SystemName && MachineName == other.MachineName && DomainName == other.DomainName &&
			       CurrentLoggedUsers == other.CurrentLoggedUsers && ComputerDescription == other.ComputerDescription && Monitored == other.Monitored &&
			       Nullable.Equals(LastPatchManagementReceived, other.LastPatchManagementReceived) && AgentVersion == other.AgentVersion && Favorite == other.Favorite &&
			       ThresholdID == other.ThresholdID && MonitoredAgentID == other.MonitoredAgentID && Created.Equals(other.Created) && Modified.Equals(other.Modified) && Online == other.Online &&
			       ReportedFromIP == other.ReportedFromIP && AppViewUrl == other.AppViewUrl && Motherboard == other.Motherboard && Processor == other.Processor && Memory == other.Memory &&
			       Display == other.Display && Sound == other.Sound && ProcessorCoresCount == other.ProcessorCoresCount && SystemDrive == other.SystemDrive && ProcessorClock == other.ProcessorClock &&
			       Vendor == other.Vendor && VendorSerialNumber == other.VendorSerialNumber && VendorBrandModel == other.VendorBrandModel && ProductName == other.ProductName &&
			       Equals(MacAddresses, other.MacAddresses) && Equals(IpAddresses, other.IpAddresses) && Equals(HardwareDisks, other.HardwareDisks) && OS == other.OS && OSType == other.OSType &&
			       OSVersion == other.OSVersion && OSBuild == other.OSBuild && WindowsSerialNumber == other.WindowsSerialNumber && Office == other.Office && OfficeSP == other.OfficeSP &&
			       OfficeOEM == other.OfficeOEM && OfficeSerialNumber == other.OfficeSerialNumber && OfficeFullVersion == other.OfficeFullVersion && LastLoginUser == other.LastLoginUser;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IAgent other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = AgentID;
				hashCode = (hashCode * 397) ^ (MachineID != null ? MachineID.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (DeviceGuid != null ? DeviceGuid.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ CustomerID;
				hashCode = (hashCode * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ FolderID.GetHashCode();
				hashCode = (hashCode * 397) ^ (AgentName != null ? AgentName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (SystemName != null ? SystemName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (MachineName != null ? MachineName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (DomainName != null ? DomainName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (CurrentLoggedUsers != null ? CurrentLoggedUsers.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ComputerDescription != null ? ComputerDescription.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Monitored.GetHashCode();
				hashCode = (hashCode * 397) ^ LastPatchManagementReceived.GetHashCode();
				hashCode = (hashCode * 397) ^ (AgentVersion != null ? AgentVersion.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Favorite.GetHashCode();
				hashCode = (hashCode * 397) ^ ThresholdID.GetHashCode();
				hashCode = (hashCode * 397) ^ MonitoredAgentID.GetHashCode();
				hashCode = (hashCode * 397) ^ Created.GetHashCode();
				hashCode = (hashCode * 397) ^ Modified.GetHashCode();
				hashCode = (hashCode * 397) ^ Online.GetHashCode();
				hashCode = (hashCode * 397) ^ (ReportedFromIP != null ? ReportedFromIP.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (AppViewUrl != null ? AppViewUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Motherboard != null ? Motherboard.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Processor != null ? Processor.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Memory.GetHashCode();
				hashCode = (hashCode * 397) ^ (Display != null ? Display.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Sound != null ? Sound.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ ProcessorCoresCount.GetHashCode();
				hashCode = (hashCode * 397) ^ (SystemDrive != null ? SystemDrive.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ProcessorClock != null ? ProcessorClock.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Vendor != null ? Vendor.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (VendorSerialNumber != null ? VendorSerialNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (VendorBrandModel != null ? VendorBrandModel.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ProductName != null ? ProductName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (MacAddresses != null ? MacAddresses.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (IpAddresses != null ? IpAddresses.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (HardwareDisks != null ? HardwareDisks.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OS != null ? OS.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OSType != null ? OSType.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OSVersion != null ? OSVersion.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OSBuild != null ? OSBuild.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (WindowsSerialNumber != null ? WindowsSerialNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Office != null ? Office.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OfficeSP != null ? OfficeSP.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ OfficeOEM.GetHashCode();
				hashCode = (hashCode * 397) ^ (OfficeSerialNumber != null ? OfficeSerialNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OfficeFullVersion != null ? OfficeFullVersion.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LastLoginUser != null ? LastLoginUser.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
