using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Comment : IComment
	{
		public DateTime Date { get; set; }
		
		[JsonProperty("Comment")]
		public string Message { get; set; }
		
		public int? EndUserID { get; set; }
		public int? TechnicianContactID { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool IsInternal { get; set; }
	}
}
