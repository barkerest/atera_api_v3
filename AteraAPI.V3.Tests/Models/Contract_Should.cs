using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Contract_Should : Model_Should<IContract>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IContract[]
			{
				CreateModel(() => new
				{
					ContractID = 1234,
					ContractName = "Contract 1",
					CustomerID = 1,
					CustomerName = "Customer 1",
					ContractType="Hourly"
				}),
				CreateModel(() => new
				{
					ContractID = 4321,
					ContractName = "Contract 2",
					CustomerName = "Customer 2",
					Active = true,
					Default = true,
					Taxable = true
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IContract item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithContractID(IContract item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.ContractID,
				item.ContractID + 6789);
		}
		
	}
}
