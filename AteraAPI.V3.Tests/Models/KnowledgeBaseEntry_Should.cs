using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class KnowledgeBaseEntry_Should : Model_Should<IKnowledgeBaseEntry>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new[]
			{
				CreateModel(()=>new
					{
						KBID = 1001,
						Timestamp = DateTime.Now
					}),
			};
			return data.Select(x => new object[] {x});
		}
		
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IKnowledgeBaseEntry item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithKBID(IKnowledgeBaseEntry item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.KBID,
				5005);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithPriority(IKnowledgeBaseEntry item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Priority,
				5);
		}
		
	}
}
