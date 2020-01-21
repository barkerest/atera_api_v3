using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class InvoiceLineItem : IInvoiceLineItem
	{
		public string Product            { get; set; }
		public string Description        { get; set; }
		public double Quantity           { get; set; }
		public double Rate               { get; set; }
		public double? TaxPercentage      { get; set; }
		public double? DiscountPercentage { get; set; }
		public double Total              { get; set; }
		public double Subtotal           { get; set; }
		public double? Tax                { get; set; }
		public int    LineIdx            { get; set; }

		public override string ToString()
		{
			return $"({LineIdx}) {Quantity:0.00} {Product}";
		}

		private bool Equals(IInvoiceLineItem other)
		{
			return Product == other.Product && Description == other.Description && Quantity.Equals(other.Quantity) && Rate.Equals(other.Rate) && TaxPercentage.Equals(other.TaxPercentage) &&
			       DiscountPercentage.Equals(other.DiscountPercentage) && Total.Equals(other.Total) && Subtotal.Equals(other.Subtotal) && Tax.Equals(other.Tax) && LineIdx == other.LineIdx;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IInvoiceLineItem other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Product != null ? Product.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
				hashCode = (hashCode * 397) ^ Rate.GetHashCode();
				hashCode = (hashCode * 397) ^ TaxPercentage.GetHashCode();
				hashCode = (hashCode * 397) ^ DiscountPercentage.GetHashCode();
				hashCode = (hashCode * 397) ^ Total.GetHashCode();
				hashCode = (hashCode * 397) ^ Subtotal.GetHashCode();
				hashCode = (hashCode * 397) ^ Tax.GetHashCode();
				hashCode = (hashCode * 397) ^ LineIdx;
				return hashCode;
			}
		}
	}
}
