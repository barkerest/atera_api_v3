using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Contract : IContract
	{
		public int ContractID { get; set; }
		public string ContractName { get; set; }
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
		public string ContractType { get; set; }
		public bool Active { get; set; }
		public bool Default { get; set; }
		public bool Taxable { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<RetainerContractDetails>))]
		public IContractRetainerDetails RetainerFlatFeeContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<HourlyContract>))]
		public IContractHourlyDetails HourlyContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<BlockHoursContract>))]
		public IContractHourBlockDetails BlockHoursContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<BlockMoneyContract>))]
		public IContractMoneyBlockDetails BlockMoneyContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<RemoteMonitoringContract>))]
		public IContractRemoteMonitoringDetails RemoteMonitoringContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<OnlineBackupContract>))]
		public IContractOnlineBackupDetails OnlineBackupContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<ProjectOneTimeFeeContract>))]
		public IContractOneTimeFeeDetails ProjectOneTimeFeeContract { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<ProjectHourlyRateContract>))]
		public IContractProjectHourlyDetails ProjectHourlyRateContract { get; set; }
	}
}
