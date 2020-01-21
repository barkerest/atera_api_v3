using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Ticket_Should : Model_Should<ITicket>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new ITicket[]
			{
				CreateModel(()=>new
				{
					TicketTitle = "Test Ticket 1",
					TicketPriority = "Low",
					TicketImpact = "No Impact",
					EndUserID = 40,
					EndUserEmail = "a@b.c",
					EndUserFirstName = "A",
					EndUserLastName = "B",
					TicketCreatedDate = DateTime.Now
				}),
				CreateModel(()=>new
				{
					TicketID = 1001,
					TicketTitle       = "Test Ticket 2",
					TicketPriority    = "High",
					TicketImpact      = "Major",
					EndUserID         = 14,
					EndUserEmail      = "c@b.a",
					EndUserFirstName  = "C",
					EndUserLastName   = "B",
					TicketCreatedDate = DateTime.Now
				}),
			};

			return data.Select(x => new object[] {x});
		}

		protected override void AdjustProperties(ITicket item)
		{
			var isNew = (item.TicketID == 0);
			var onlyNew = new[] {"EndUserID", "EndUserEmail", "EndUserFirstName", "EndUserLastName", "Description"};
			foreach (var p in Properties)
			{
				if (onlyNew.Contains(p.Name)) p.Serialize = isNew;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void SerializeWithWritableProperties(ITicket item)
		{
			TestThatWritablePropertiesAreSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void SerializeWithoutReadonlyProperties(ITicket item)
		{
			TestThatReadonlyPropertiesAreNotSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithTicketID(ITicket item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.TicketID,
				item.TicketID + 5678);
		}
	}
}
