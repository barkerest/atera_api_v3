using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class OnlineBackupContract : IContractOnlineBackupDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate RatePerGB { get; set; }
		
		public string CountBy { get; set; }
		
		public string BillingPeriod { get; set; }
	}
}
