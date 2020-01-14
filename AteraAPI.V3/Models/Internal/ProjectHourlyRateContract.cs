using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class ProjectHourlyRateContract : IContractProjectHourlyDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate PrimaryRate { get; }
		
		[JsonConverter(typeof(ConcreteArrayConverter<IRate,Rate>))]
		public IRate[] AdditionalRates { get; }
	}
}
