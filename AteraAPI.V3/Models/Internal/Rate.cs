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
	}
}
