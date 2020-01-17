using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Duration_Should : Model_Should<IDuration>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IDuration[]
			{
				CreateModel(() => new
				{
					TicketID             = 5,
					OnSLADurationHours   = 1.25,
					OffSiteDurationHours = 1.25,
					TotalDurationHours   = 1.25
				}),
				CreateModel(() => new
				{
					TicketID            = 6,
					OffSLADurationHours = 2.3,
					OnSLADurationHours  = 0.7,
					OnSiteDurationHours = 3.0,
					TotalDurationHours  = 3.0
				})
			};

			return data.Select(x => new object[] {x});
		}

		// not testing serializing since this is meant to be a read-only model.
		
		protected override void AdjustProperties(IDuration item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithTicketID(IDuration item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.TicketID,
				item.TicketID + 42);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithTotalDurationHours(IDuration item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.TotalDurationHours,
				item.TotalDurationHours + 3.2);
		}
	}
}
