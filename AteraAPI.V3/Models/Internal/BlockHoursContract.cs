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
	}
}
