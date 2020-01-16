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
			return $"{Description} ({Amount:#,##0.00})";
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is IRate other)) return false;
			return other.RateID == RateID
			       && other.Amount == Amount
			       && other.SKU == SKU
			       && other.Category == Category
			       && other.Archived == Archived;
		}
	}
}
