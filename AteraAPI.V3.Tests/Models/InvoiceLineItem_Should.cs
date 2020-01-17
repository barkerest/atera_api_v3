using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class InvoiceLineItem_Should : Model_Should<IInvoiceLineItem>
	{

		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IInvoiceLineItem[]
			{
				CreateModel(() => new
				{
					LineIdx = 1,
					Product = "Labor",
					Description = "10 hours of labor",
					Quantity = 10.0,
					Rate = 127.5,
					Subtotal = 1275.0,
					Tax = 0.0,
					Total = 1275.0
				})
			};
			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IInvoiceLineItem item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithProduct(IInvoiceLineItem item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Product,
				"Manual Labor");
		}

	}
}
