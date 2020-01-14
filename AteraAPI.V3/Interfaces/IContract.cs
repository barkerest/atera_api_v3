using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for contracts.
	/// </summary>
	public interface IContract
	{
		/// <summary>
		/// The contract ID.
		/// </summary>
		int ContractID { get; }
		
		/// <summary>
		/// The contract name.
		/// </summary>
		string ContractName { get; }
		
		/// <summary>
		/// The customer ID.
		/// </summary>
		int CustomerID { get; }
		
		/// <summary>
		/// The customer name.
		/// </summary>
		string CustomerName { get; }
		
		/// <summary>
		/// The contract type.
		/// </summary>
		string ContractType { get; }
		
		/// <summary>
		/// Is the contract archived.
		/// </summary>
		bool Active { get; }
		
		/// <summary>
		/// Is this the default contract for the customer.
		/// </summary>
		bool Default { get; }
		
		/// <summary>
		/// Is the contract taxable.
		/// </summary>
		bool Taxable { get; }
		
		/// <summary>
		/// The start date for the contract.
		/// </summary>
		DateTime StartDate { get; }
		
		/// <summary>
		/// The end date for the contract.
		/// </summary>
		DateTime EndDate { get; }
		
		/// <summary>
		/// Details about a retainer flat fee contract.
		/// </summary>
		IContractRetainerDetails RetainerFlatFeeContract { get; }
		
		/// <summary>
		/// Details about an hourly contract.
		/// </summary>
		IContractHourlyDetails HourlyContract { get; }
		
		/// <summary>
		/// Details about a block hours contract.
		/// </summary>
		IContractHourBlockDetails BlockHoursContract { get; }
		
		/// <summary>
		/// Details about a block money contract.
		/// </summary>
		IContractMoneyBlockDetail BlockMoneyContract { get; }
		
		/// <summary>
		/// Details about a remote monitoring contract.
		/// </summary>
		IContractRemoteMonitoringDetails RemoteMonitoringContract { get; }
		
		/// <summary>
		/// Details about an online backup contract.
		/// </summary>
		IContractOnlineBackupDetails OnlineBackupContract { get; }
		
		/// <summary>
		/// Details about a project one time fee contract.
		/// </summary>
		IContractOneTimeFeeDetails ProjectOneTimeFeeContract { get; }
		
		/// <summary>
		/// Details about a project hourly rate contract.
		/// </summary>
		IContractProjectHourlyDetails ProjectHourlyRateContract { get; }
	}
}
