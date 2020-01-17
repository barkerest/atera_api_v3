using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class RetainerContractDetails : IContractRetainerDetails
	{
		public int Quantity { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate Rate { get; set; }
		
		public string BillingPeriod { get; set; }

		public override string ToString()
		{
			return $"Retainer: Qty {Quantity}";
		}

		private bool Equals(IContractRetainerDetails other)
		{
			return Quantity == other.Quantity && Equals(Rate, other.Rate) && BillingPeriod == other.BillingPeriod;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is IContractRetainerDetails other)) return false;
			return Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Quantity;
				hashCode = (hashCode * 397) ^ (Rate != null ? Rate.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
