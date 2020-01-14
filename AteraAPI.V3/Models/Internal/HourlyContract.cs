using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class HourlyContract : IContractHourlyDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate PrimaryRate { get; set; }
		
		[JsonConverter(typeof(ConcreteArrayConverter<IRate,Rate>))]
		public IRate[] AdditionalRates { get; set; }
		
		public string BillingPeriod { get; set; }
	}
}
