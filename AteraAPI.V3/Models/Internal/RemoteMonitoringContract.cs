using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class RemoteMonitoringContract : IContractRemoteMonitoringDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate RatePerDevice { get; set; }
		
		public string CountBy { get; set; }
		
		public string BillingPeriod { get; set; }
	}
}
