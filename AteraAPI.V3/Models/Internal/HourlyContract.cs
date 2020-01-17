using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class HourlyContract : IContractHourlyDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate PrimaryRate { get; set; }

		[JsonConverter(typeof(ConcreteArrayConverter<IRate, Rate>))]
		public IRate[] AdditionalRates { get; set; }

		public string BillingPeriod { get; set; }

		public override string ToString()
		{
			return $"Hourly: {PrimaryRate} per hour";
		}

		private bool Equals(IContractHourlyDetails other)
		{
			return Equals(PrimaryRate, other.PrimaryRate) && Equals(AdditionalRates, other.AdditionalRates) && BillingPeriod == other.BillingPeriod;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractHourlyDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (PrimaryRate != null ? PrimaryRate.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (AdditionalRates != null ? AdditionalRates.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
