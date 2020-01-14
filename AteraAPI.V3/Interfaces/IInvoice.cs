using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for invoices.
	/// </summary>
	public interface IInvoice
	{
		/// <summary>
		/// The GUID for the invoice.
		/// </summary>
		string InvoiceId { get; }
		
		/// <summary>
		/// The numeric invoice number.
		/// </summary>
		int InvoiceNumber { get; }
		
		/// <summary>
		/// Fixed width, zero padded invoice number.
		/// </summary>
		string InvoiceNumberAsString { get; }
		
		/// <summary>
		/// Invoice total.
		/// </summary>
		double Total { get; }
		
		/// <summary>
		/// Invoice subtotal.
		/// </summary>
		double Subtotal { get; }
		
		/// <summary>
		/// Invoice tax.
		/// </summary>
		double Tax { get; }
		
		/// <summary>
		/// Tax rate.
		/// </summary>
		double TaxPercentage { get; }
		
		/// <summary>
		/// The invoice date.
		/// </summary>
		DateTime InvoiceDate { get; }
		
		/// <summary>
		/// The name of the contract being billed under.
		/// </summary>
		string ContractName { get; }
		
		/// <summary>
		/// The period start date for the invoice.
		/// </summary>
		DateTime PeriodStartDate { get; }
		
		/// <summary>
		/// The period end date for the invoice.
		/// </summary>
		DateTime PeriodEndDate { get; }
		
		/// <summary>
		/// The currency symbol for the invoice.
		/// </summary>
		string Currency { get; }
		
		/// <summary>
		/// The line items for the invoice.
		/// </summary>
		IInvoiceLineItem[] LineItems { get; }
		
		/// <summary>
		/// The sender of the invoice.
		/// </summary>
		IInvoiceContact From { get; }
		
		/// <summary>
		/// The receiver of the invoice.
		/// </summary>
		IInvoiceContact To { get; }
	}
}
