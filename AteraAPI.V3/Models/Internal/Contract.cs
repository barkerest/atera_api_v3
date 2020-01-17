using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Contract : IContract
	{
		public int      ContractID   { get; set; }
		public string   ContractName { get; set; }
		public int      CustomerID   { get; set; }
		public string   CustomerName { get; set; }
		public string   ContractType { get; set; }
		public bool     Active       { get; set; }
		public bool     Default      { get; set; }
		public bool     Taxable      { get; set; }
		public DateTime StartDate    { get; set; }
		public DateTime EndDate      { get; set; }

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

		public override string ToString()
		{
			return ContractName;
		}

		private bool Equals(IContract other)
		{
			return ContractID == other.ContractID && ContractName == other.ContractName && CustomerID == other.CustomerID && CustomerName == other.CustomerName && ContractType == other.ContractType &&
			       Active == other.Active && Default == other.Default && Taxable == other.Taxable && StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate) &&
			       Equals(RetainerFlatFeeContract, other.RetainerFlatFeeContract) && Equals(HourlyContract, other.HourlyContract) && Equals(BlockHoursContract, other.BlockHoursContract) &&
			       Equals(BlockMoneyContract, other.BlockMoneyContract) && Equals(RemoteMonitoringContract, other.RemoteMonitoringContract) &&
			       Equals(OnlineBackupContract, other.OnlineBackupContract) && Equals(ProjectOneTimeFeeContract, other.ProjectOneTimeFeeContract) &&
			       Equals(ProjectHourlyRateContract, other.ProjectHourlyRateContract);
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContract other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = ContractID;
				hashCode = (hashCode * 397) ^ (ContractName != null ? ContractName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ CustomerID;
				hashCode = (hashCode * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ContractType != null ? ContractType.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Active.GetHashCode();
				hashCode = (hashCode * 397) ^ Default.GetHashCode();
				hashCode = (hashCode * 397) ^ Taxable.GetHashCode();
				hashCode = (hashCode * 397) ^ StartDate.GetHashCode();
				hashCode = (hashCode * 397) ^ EndDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (RetainerFlatFeeContract != null ? RetainerFlatFeeContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (HourlyContract != null ? HourlyContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BlockHoursContract != null ? BlockHoursContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BlockMoneyContract != null ? BlockMoneyContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (RemoteMonitoringContract != null ? RemoteMonitoringContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OnlineBackupContract != null ? OnlineBackupContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ProjectOneTimeFeeContract != null ? ProjectOneTimeFeeContract.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ProjectHourlyRateContract != null ? ProjectHourlyRateContract.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
