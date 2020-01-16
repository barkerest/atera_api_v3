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
		
		[JsonConverter(typeof(ConcreteArrayConverter<IRate,Rate>))]
		public IRate[] AdditionalRates { get; set; }
		
		public bool CommitRollover { get; set; }
		
		public string BillingPeriod { get; set; }
	}
}
