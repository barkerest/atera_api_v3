using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class HardwareDisk_Should : Model_Should<IHardwareDisk>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IHardwareDisk[]
			{
				CreateModel(() => new
				{
					Drive = "C:",
					Total = (long)(2.5 * (1L<<40)),
					Used = (long)(2.1 * (1L<<40)),
					Free = (long)(0.4 * (1L<<40))
				})
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IHardwareDisk item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithDrive(IHardwareDisk item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Drive,
				"X:");
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithTotal(IHardwareDisk item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Total,
				512L<<30);
		}
		
	}
}
