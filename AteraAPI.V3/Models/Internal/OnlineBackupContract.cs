using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class OnlineBackupContract : IContractOnlineBackupDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate RatePerGB { get; set; }
		
		public string CountBy { get; set; }
		
		public string BillingPeriod { get; set; }


		public override string ToString()
		{
			return $"Online Backup: {RatePerGB} per GB";
		}


		private bool Equals(IContractOnlineBackupDetails other)
		{
			return Equals(RatePerGB, other.RatePerGB) && CountBy == other.CountBy && BillingPeriod == other.BillingPeriod;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractOnlineBackupDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (RatePerGB != null ? RatePerGB.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (CountBy != null ? CountBy.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
