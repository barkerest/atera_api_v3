using System;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Invoice : IInvoice
	{
		public string   InvoiceId             { get; set; }
		public int      InvoiceNumber         { get; set; }
		public string   InvoiceNumberAsString { get; set; }
		public double   Total                 { get; set; }
		public double   Subtotal              { get; set; }
		public double?  Tax                   { get; set; }
		public double?  TaxPercentage         { get; set; }
		public DateTime InvoiceDate           { get; set; }
		public string   ContractName          { get; set; }
		public DateTime PeriodStartDate       { get; set; }
		public DateTime PeriodEndDate         { get; set; }
		public string   Currency              { get; set; }

		[JsonConverter(typeof(ConcreteArrayConverter<IInvoiceLineItem, InvoiceLineItem>))]
		public IInvoiceLineItem[] LineItems { get; set; }

		[JsonConverter(typeof(ConcreteConverter<InvoiceContact>))]
		public IInvoiceContact From { get; set; }

		[JsonConverter(typeof(ConcreteConverter<InvoiceContact>))]
		public IInvoiceContact To { get; set; }

		public override string ToString()
		{
			return InvoiceNumberAsString;
		}

		private bool Equals(IInvoice other)
		{
			if (!(InvoiceId == other.InvoiceId && InvoiceNumber == other.InvoiceNumber && InvoiceNumberAsString == other.InvoiceNumberAsString && Total.Equals(other.Total) &&
			       Subtotal.Equals(other.Subtotal) && Nullable.Equals(Tax, other.Tax) && Nullable.Equals(TaxPercentage, other.TaxPercentage) && InvoiceDate.Equals(other.InvoiceDate) &&
			       ContractName == other.ContractName && PeriodStartDate.Equals(other.PeriodStartDate) && PeriodEndDate.Equals(other.PeriodEndDate) && Currency == other.Currency &&
			       Equals(From, other.From) && Equals(To, other.To))) return false;

			if (LineItems is null && other.LineItems is null) return true;
			if (LineItems is null || other.LineItems is null) return false;
			return LineItems.OrderBy(x => x.LineIdx).SequenceEqual(other.LineItems.OrderBy(x => x.LineIdx));
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IInvoice other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (InvoiceId != null ? InvoiceId.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ InvoiceNumber;
				hashCode = (hashCode * 397) ^ (InvoiceNumberAsString != null ? InvoiceNumberAsString.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Total.GetHashCode();
				hashCode = (hashCode * 397) ^ Subtotal.GetHashCode();
				hashCode = (hashCode * 397) ^ Tax.GetHashCode();
				hashCode = (hashCode * 397) ^ TaxPercentage.GetHashCode();
				hashCode = (hashCode * 397) ^ InvoiceDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (ContractName != null ? ContractName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ PeriodStartDate.GetHashCode();
				hashCode = (hashCode * 397) ^ PeriodEndDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (From != null ? From.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (To != null ? To.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LineItems?.Sum(x => x.GetHashCode()) ?? 0);
				return hashCode;
			}
		}
	}
}
