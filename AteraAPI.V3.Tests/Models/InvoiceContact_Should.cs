using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class InvoiceContact_Should : Model_Should<IInvoiceContact>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IInvoiceContact[]
			{
				CreateModel(() => new
				{
					CompanyName = "Test Company",
					ContactFirstName = "George",
					ContactLastName = "Jetson",
					ContactFullName = "George Jetson",
					Email = "gj@example.com"
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IInvoiceContact item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithEmail(IInvoiceContact item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Email,
				"george@jetson.com"
				);
		}
		
	}
}
