using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Rate_Should : Model_Should<IRate>
	{

		public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var data = new IRate[]
			{
				CreateModel(()=>new
				{
					Description = "Test Rate 1",
					Amount = 123.45
				}),
				CreateModel(()=>new
				{
					RateID = 5,
					Description = "Test Rate 2",
					Amount = 456.70
				}),
				CreateModel(()=>new
				{
					RateID = 42,
					Description = "Test Rate 3",
					Amount = 34.50,
					Archived = true
				}),
			};

			return data.Select(x => new object[] {x});
		}

		protected override void AdjustProperties(IRate item)
		{
			var isNew = (item.RateID == 0);
			foreach (var p in Properties)
			{
				if (p.Name == "Archived")
				{
					p.Serialize = !isNew;
				}
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithWritableProperties(IRate item)
		{
			TestThatWritablePropertiesAreSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithoutReadonlyProperties(IRate item)
		{
			TestThatReadonlyPropertiesAreNotSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithRateID(IRate item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.RateID,
				item.RateID + 5678);
		}
		
	}
}
