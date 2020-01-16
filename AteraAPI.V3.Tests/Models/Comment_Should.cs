using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Comment_Should : Model_Should<IComment>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IComment[]
			{
				CreateModel(()=> new
				{
					Date = DateTime.Now,
					Message = "Hello World",
					EndUserID = 5,
					Email = "bob@example.com",
					FirstName = "Bob",
					LastName = "Doe"
				}),
				CreateModel(() => new 
				{
					Date = DateTime.Now,
					Message = "Foo Bar Baz",
					TechnicianContactID = 10,
					Email = "john@example.com",
					FirstName = "John",
					LastName="Smith",
					IsInternal = true
				}),
			};

			return data.Select(x => new object[] {x});
		}
		
		// not testing serializing since this is meant to be a read-only model.

		protected override void AdjustProperties(IComment item)
		{
			foreach (var p in Properties)
			{
				p.Serialize = true;
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithComment(IComment item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.Message,
				"The new message.");
		}
		
	}
}
