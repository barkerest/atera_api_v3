using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class RemoteMonitoringContract : IContractRemoteMonitoringDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate RatePerDevice { get; set; }
		
		public string CountBy { get; set; }
		
		public string BillingPeriod { get; set; }

		public override string ToString()
		{
			return $"Monitoring: {RatePerDevice} per {CountBy}";
		}

		private bool Equals(IContractRemoteMonitoringDetails other)
		{
			return Equals(RatePerDevice, other.RatePerDevice) && CountBy == other.CountBy && BillingPeriod == other.BillingPeriod;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractRemoteMonitoringDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (RatePerDevice != null ? RatePerDevice.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (CountBy != null ? CountBy.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
