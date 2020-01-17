using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class BlockMoneyContract : IContractMoneyBlockDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate ContractAmount { get; set; }

		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate PrimaryRate { get; set; }

		[JsonConverter(typeof(ConcreteArrayConverter<IRate, Rate>))]
		public IRate[] AdditionalRates { get; set; }

		public bool CommitRollover { get; set; }

		public string BillingPeriod { get; set; }

		public override string ToString()
		{
			return $"Block Money: {ContractAmount}";
		}

		protected bool Equals(IContractMoneyBlockDetails other)
		{
			return Equals(ContractAmount, other.ContractAmount) && Equals(PrimaryRate, other.PrimaryRate) && Equals(AdditionalRates, other.AdditionalRates) && CommitRollover == other.CommitRollover &&
			       BillingPeriod == other.BillingPeriod;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractMoneyBlockDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (ContractAmount != null ? ContractAmount.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (PrimaryRate != null ? PrimaryRate.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (AdditionalRates != null ? AdditionalRates.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ CommitRollover.GetHashCode();
				hashCode = (hashCode * 397) ^ (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
