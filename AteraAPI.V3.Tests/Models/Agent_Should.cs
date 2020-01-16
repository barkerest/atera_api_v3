using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Extensions;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Agent_Should : Model_Should<IAgent>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IAgent[]
			{
				CreateModel(() => new
				{
					AgentID    = 11,
					DeviceGuid = Guid.NewGuid().ToString(),
					CustomerID = 20,
					AgentName  = "Test Agent 1",
					Monitored  = true
				}),
				CreateModel(() => new
				{
					AgentID    = 321,
					DeviceGuid = Guid.NewGuid().ToString(),
					CustomerID = 101,
					FolderID   = 3,
					AgentName  = "Test Agent 2",
					Monitored  = false,
					Favorite   = true
				}),
			};

			return data.Select(x => new object[] {x});
		}

		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IAgent item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithAgentID(IAgent item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.AgentID,
				item.AgentID + 5678);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithAgentName(IAgent item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.AgentName,
				"Test Agent 42");
		}
	}
}
