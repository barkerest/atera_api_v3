using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class InvoiceLineItem : IInvoiceLineItem
	{
		public string Product { get; set; }
		public string Description { get; set; }
		public double Quantity { get; set; }
		public double Rate { get; set; }
		public double TaxPercentage { get; set; }
		public double DiscountPercentage { get; set; }
		public double Total { get; set; }
		public double Subtotal { get; set; }
		public double Tax { get; set; }
		public int LineIdx { get; set; }
	}
}
