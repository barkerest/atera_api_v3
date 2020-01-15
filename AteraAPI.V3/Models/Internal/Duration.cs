using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AteraAPI.V3.Models.Internal
{
	internal class Duration : IDuration
	{
		[JsonProperty("ticketId")]
		public int TicketID { get; set; }
		
		public double OffSLADurationHours { get; set; }
		
		public double OffSiteDurationHours { get; set; }
		
		public double OnSLADurationHours { get; set; }
		
		public double OnSiteDurationHours { get; set; }
		
		public double TotalDurationHours { get; set; }
	}
}
