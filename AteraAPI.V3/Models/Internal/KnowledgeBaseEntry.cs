using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class KnowledgeBaseEntry : IKnowledgeBaseEntry
	{
		public int KBID { get; set; }

		[JsonProperty("KBTimestamp")] public DateTime Timestamp { get; set; }

		[JsonProperty("KBContext")] public string Context { get; set; }

		[JsonProperty("KBProduct")] public string Product { get; set; }

		[JsonProperty("KBRating_Yes")] public int Rating_Yes { get; set; }

		[JsonProperty("KBRating_No")] public int Rating_No { get; set; }

		[JsonProperty("KBRating_Views")] public int Rating_Views { get; set; }

		[JsonProperty("KBLastModified")] public DateTime LastModified { get; set; }

		[JsonProperty("KBIsPrivate")] public bool IsPrivate { get; set; }

		[JsonProperty("KBStatus")] public int Status { get; set; }

		[JsonProperty("KBPriority")] public int Priority { get; set; }

		[JsonProperty("KBKeywords")] public string Keywords { get; set; }

		[JsonProperty("KBAddress")] public string Address { get; set; }

		public override string ToString()
		{
			return $"KB{KBID:0000000}";
		}

		private bool Equals(IKnowledgeBaseEntry other)
		{
			return KBID == other.KBID && Timestamp.Equals(other.Timestamp) && Context == other.Context && Product == other.Product && Rating_Yes == other.Rating_Yes && Rating_No == other.Rating_No &&
			       Rating_Views == other.Rating_Views && LastModified.Equals(other.LastModified) && IsPrivate == other.IsPrivate && Status == other.Status && Priority == other.Priority &&
			       Keywords == other.Keywords && Address == other.Address;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IKnowledgeBaseEntry other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = KBID;
				hashCode = (hashCode * 397) ^ Timestamp.GetHashCode();
				hashCode = (hashCode * 397) ^ (Context != null ? Context.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Product != null ? Product.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Rating_Yes;
				hashCode = (hashCode * 397) ^ Rating_No;
				hashCode = (hashCode * 397) ^ Rating_Views;
				hashCode = (hashCode * 397) ^ LastModified.GetHashCode();
				hashCode = (hashCode * 397) ^ IsPrivate.GetHashCode();
				hashCode = (hashCode * 397) ^ Status;
				hashCode = (hashCode * 397) ^ Priority;
				hashCode = (hashCode * 397) ^ (Keywords != null ? Keywords.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
