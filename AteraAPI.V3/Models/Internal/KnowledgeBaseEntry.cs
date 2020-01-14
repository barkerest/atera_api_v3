using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class KnowledgeBaseEntry : IKnowledgeBaseEntry
	{
		public int KBID { get; set; }
		
		[JsonProperty("KBTimestamp")]
		public DateTime Timestamp { get; set; }
		
		[JsonProperty("KBContext")]
		public string Context { get; set; }
		
		[JsonProperty("KBProduct")]
		public string Product { get; set; }
		
		[JsonProperty("KBRating_Yes")]
		public int Rating_Yes { get; set; }
		
		[JsonProperty("KBRating_No")]
		public int Rating_No { get; set; }
		
		[JsonProperty("KBRating_Views")]
		public int Rating_Views { get; set; }
		
		[JsonProperty("KBLastModified")]
		public DateTime LastModified { get; set; }
		
		[JsonProperty("KBIsPrivate")]
		public bool IsPrivate { get; set; }
		
		[JsonProperty("KBStatus")]
		public int Status { get; set; }
		
		[JsonProperty("KBPriority")]
		public int Priority { get; set; }
		
		[JsonProperty("KBKeywords")]
		public string Keywords { get; set; }
		
		[JsonProperty("KBAddress")]
		public string Address { get; set; }
	}
}
