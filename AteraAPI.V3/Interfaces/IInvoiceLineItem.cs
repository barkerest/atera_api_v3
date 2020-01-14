namespace AteraAPI.V3.Interfaces
{
	public interface IInvoiceLineItem
	{
		/// <summary>
		/// The product name.
		/// </summary>
		string Product { get; }
		
		/// <summary>
		/// Description of the line item.
		/// </summary>
		string Description { get; }
		
		/// <summary>
		/// The quantity.
		/// </summary>
		double Quantity { get; }
		
		/// <summary>
		/// The billing rate for the line item.
		/// </summary>
		double Rate { get; }
		
		/// <summary>
		/// Tax rate.
		/// </summary>
		double TaxPercentage { get; }
		
		/// <summary>
		/// Discount rate.
		/// </summary>
		double DiscountPercentage { get; }
		
		/// <summary>
		/// Line total.
		/// </summary>
		double Total { get; }
		
		/// <summary>
		/// Line subtotal.
		/// </summary>
		double Subtotal { get; }
		
		/// <summary>
		/// Line tax.
		/// </summary>
		double Tax { get; }
		
		/// <summary>
		/// Line index.
		/// </summary>
		int LineIdx { get; }
	}
}
