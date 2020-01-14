using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class InvoiceApiEndpoint : CommonApiEndpointBase<IInvoice, Invoice>, IInvoiceApiEndpoint
	{
		internal InvoiceApiEndpoint(ApiContext context) 
			: base(context, "billing/invoices", m => m.InvoiceNumber)
		{
		}
	}
}
