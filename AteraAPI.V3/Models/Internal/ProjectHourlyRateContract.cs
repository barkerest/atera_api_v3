using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class ProjectHourlyRateContract : IContractProjectHourlyDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate PrimaryRate { get; set; }
		
		[JsonConverter(typeof(ConcreteArrayConverter<IRate,Rate>))]
		public IRate[] AdditionalRates { get; set; }

		public override string ToString()
		{
			return $"Project: {PrimaryRate} per hour";
		}

		private bool Equals(IContractProjectHourlyDetails other)
		{
			return Equals(PrimaryRate, other.PrimaryRate) && Equals(AdditionalRates, other.AdditionalRates);
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractProjectHourlyDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((PrimaryRate != null ? PrimaryRate.GetHashCode() : 0) * 397) ^ (AdditionalRates != null ? AdditionalRates.GetHashCode() : 0);
			}
		}
	}
}
