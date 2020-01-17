using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class ContractHourlyDetails_Should : Model_Should<IContractHourlyDetails>
	{
		public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var rate = InternalModel.CreateInstanceOf<IRate>(("Amount", 123.45));
			var data = new []
			{
				CreateModel(() => new
				{
					BillingPeriod = "Weekly",
					PrimaryRate = rate
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IContractHourlyDetails item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithBillingPeriod(IContractHourlyDetails item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.BillingPeriod,
				"Monthly");
		}
	}
}
