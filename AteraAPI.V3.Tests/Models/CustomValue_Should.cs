using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class CustomValue_Should : Model_Should<ICustomValue>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new ICustomValue[]
			{
				CreateModel(() => new
				{
					ItemID        = 1234,
					Id            = Guid.NewGuid().ToString(),
					FieldName     = "test-string",
					ValueAsString = "test value"
				}),
				CreateModel(() => new
				{
					ItemID         = 4321,
					Id             = Guid.NewGuid().ToString(),
					FieldName      = "test-number",
					ValueAsDecimal = 1234.5678
				}),
				CreateModel(() => new
				{
					ItemID          = 2345,
					Id              = Guid.NewGuid().ToString(),
					FieldName       = "test-date",
					ValueAsDateTime = DateTime.Now
				}),
				CreateModel(() => new
				{
					ItemID      = 1234,
					Id          = Guid.NewGuid().ToString(),
					FieldName   = "test-bool",
					ValueAsBool = false
				}),
			};
			return data.Select(x => new object[] {x});
		}

		// not testing serializing since this is meant to be a read-only model.
		
		protected override void AdjustProperties(ICustomValue item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithItemID(ICustomValue item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.ItemId,
				item.ItemId + 5678);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithId(ICustomValue item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Id,
				Guid.NewGuid().ToString());
		}
		
		
	}
}
