using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class Rate : IRate
	{
		public int RateID { get; set; }
		
		public bool ShouldSerializeRateID() => false;
		
		public double Amount { get; set; }
		
		public string Description { get; set; }
		
		public string SKU { get; set; }
		
		public string Category { get; set; }
		
		public bool? Archived { get; set; }
		public bool ShouldSerializeArchived() => (RateID != 0);

		public override string ToString()
		{
			if (string.IsNullOrWhiteSpace(Description)) return Amount.ToString("#,##0.00");
			return $"{Amount:#,##0.00} ({Description})";
		}

		private bool Equals(IRate other)
		{
			return RateID == other.RateID && Amount.Equals(other.Amount) && Description == other.Description && SKU == other.SKU && Category == other.Category && Archived == other.Archived;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IRate other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = RateID;
				hashCode = (hashCode * 397) ^ Amount.GetHashCode();
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (SKU != null ? SKU.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Archived.GetHashCode();
				return hashCode;
			}
		}
	}
}
