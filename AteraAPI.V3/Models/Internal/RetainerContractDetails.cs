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
	}
}
