using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class ProjectOneTimeFeeContract : IContractOneTimeFeeDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate TotalAmount { get; set; }
	}
}
