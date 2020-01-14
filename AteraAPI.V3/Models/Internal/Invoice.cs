using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Invoice : IInvoice
	{
		public string InvoiceId { get; set; }
		public int InvoiceNumber { get; set; }
		public string InvoiceNumberAsString { get; set; }
		public double Total { get; set; }
		public double Subtotal { get; set; }
		public double Tax { get; set; }
		public double TaxPercentage { get; set; }
		public DateTime InvoiceDate { get; set; }
		public string ContractName { get; set; }
		public DateTime PeriodStartDate { get; set; }
		public DateTime PeriodEndDate { get; set; }
		public string Currency { get; set; }
		
		[JsonConverter(typeof(ConcreteArrayConverter<IInvoiceLineItem, InvoiceLineItem>))]
		public IInvoiceLineItem[] LineItems { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<InvoiceContact>))]
		public IInvoiceContact From { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<InvoiceContact>))]
		public IInvoiceContact To { get; set; }
	}
}
