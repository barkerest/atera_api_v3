using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Invoice_Should : Model_Should<IInvoice>
	{

		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IInvoice[]
			{
				CreateModel(() => new
				{
					InvoiceId = Guid.NewGuid().ToString(),
					InvoiceNumber = 10203,
					InvoiceNumberAsString = "00010203",
					Total = 5432.10,
					InvoiceDate = DateTime.Today,
					PeriodStartDate = DateTime.Today.AddDays(-8),
					PeriodEndDate = DateTime.Today.AddDays(-1),
					Currency = "$",
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IInvoice item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithInvoiceID(IInvoice item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.InvoiceId,
				Guid.NewGuid().ToString());
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithInvoiceDate(IInvoice item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.InvoiceDate,
				DateTime.Today.AddDays(2));
		}
	}
}
