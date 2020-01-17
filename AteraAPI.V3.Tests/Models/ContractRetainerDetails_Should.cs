using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class ContractRetainerDetails_Should : Model_Should<IContractRetainerDetails>
	{
		public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var data = new []
			{
				CreateModel(() => new
				{
					BillingPeriod = "Weekly",
					Quantity = 5
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IContractRetainerDetails item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithBillingPeriod(IContractRetainerDetails item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.BillingPeriod,
				"Monthly");
		}
	}
}
