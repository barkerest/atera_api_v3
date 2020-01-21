using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class WorkHours_Should : Model_Should<IWorkHours>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var duration = InternalModel.CreateInstanceOf<IDuration>(
				("TicketID", 5),
				("OnSLADurationHours", 1.25),
				("OffSiteDurationHours", 1.25),
				("TotalDurationHours", 1.25));
			var data = new IWorkHours[]
			{
				CreateModel(()=>new
				{
					TicketID = 1001,
					Billable = duration
				})
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IWorkHours item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithTicketID(IWorkHours item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.TicketID,
				item.TicketID + 5678);
		}

	}
}
