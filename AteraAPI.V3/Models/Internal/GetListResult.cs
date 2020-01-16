using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class GetListResult<T> : IApiModel where T : class, IApiModel
	{
		[JsonProperty("totalItemCount")]
		public int TotalItemCount { get; set; }
		
		[JsonProperty("page")]
		public int Page { get; set; }
		
		[JsonProperty("itemsInPage")]
		public int ItemsInPage { get; set; }
		
		[JsonProperty("totalPages")]
		public int TotalPages { get; set; }
		
		[JsonProperty("prevLink")]
		public string PrevLink { get; set; }
		
		[JsonProperty("items")]
		public T[] Items { get; set; }
	}
}
