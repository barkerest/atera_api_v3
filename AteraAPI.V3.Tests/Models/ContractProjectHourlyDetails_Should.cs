using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class ContractProjectHourlyDetails_Should : Model_Should<IContractProjectHourlyDetails>
	{public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var rate = InternalModel.CreateInstanceOf<IRate>(("Amount", 125.50));
			var data = new []
			{
				CreateModel(() => new
				{
					PrimaryRate = rate
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IContractProjectHourlyDetails item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithPrimaryRate(IContractProjectHourlyDetails item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.PrimaryRate,
				InternalModel.CreateInstanceOf<IRate>(("Amount", 115.0)));
		}
		
	}
}
