using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class WorkHourRecord_Should : Model_Should<IWorkHourRecord>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IWorkHourRecord[]
			{
				CreateModel(()=>new
				{
					TicketID = 1001,
					WorkHoursID = 10,
					StartWorkHour = DateTime.Now.AddHours(-1.5),
					EndWorkHour = DateTime.Now,
					TechnicianContactID = 8,
					Billable = true,
					OnCustomerSite = true,
				})
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IWorkHourRecord item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}


		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithTicketID(IWorkHourRecord item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.TicketID,
				item.TicketID + 5678);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithWorkHoursID(IWorkHourRecord item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.WorkHoursID,
				item.WorkHoursID + 5678);
		}
		
	}
}
