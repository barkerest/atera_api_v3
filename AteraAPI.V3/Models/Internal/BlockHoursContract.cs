using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class BlockHoursContract : IContractHourBlockDetails
	{
		public double HoursIncluded { get; set; }

		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate PricePerHour { get; set; }

		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate OverageRate { get; set; }

		public bool CommitRollover { get; set; }

		public string BillingPeriod { get; set; }

		public override string ToString()
		{
			return $"Block Hours: {HoursIncluded:#,##0.00}";
		}


		private bool Equals(IContractHourBlockDetails other)
		{
			return HoursIncluded.Equals(other.HoursIncluded) && Equals(PricePerHour, other.PricePerHour) && Equals(OverageRate, other.OverageRate) && CommitRollover == other.CommitRollover &&
			       BillingPeriod == other.BillingPeriod;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractHourBlockDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = HoursIncluded.GetHashCode();
				hashCode = (hashCode * 397) ^ (PricePerHour != null ? PricePerHour.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OverageRate != null ? OverageRate.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ CommitRollover.GetHashCode();
				hashCode = (hashCode * 397) ^ (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
