using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class ContractOneTimeFeeDetails_Should : Model_Should<IContractOneTimeFeeDetails>
	{
		public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var rate = InternalModel.CreateInstanceOf<IRate>(("Amount", 1000000.0));
			var data = new []
			{
				CreateModel(() => new
				{
					TotalAmount = rate
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IContractOneTimeFeeDetails item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithTotalAmount(IContractOneTimeFeeDetails item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.TotalAmount,
				InternalModel.CreateInstanceOf<IRate>(("Amount", 19.50)));
		}
	}
}
