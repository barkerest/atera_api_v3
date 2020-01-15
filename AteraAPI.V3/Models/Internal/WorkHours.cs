using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class WorkHours : IWorkHours
	{
		public int TicketID { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<Duration>))]
		public IDuration Billable { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<Duration>))]
		public IDuration NonBillable { get; set; }
	}
}
