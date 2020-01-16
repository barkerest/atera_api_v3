using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Alert_Should : Model_Should<IAlert>
	{
		public static IEnumerable<object[]> GetJsonTestParams()
		{
			var data = new IAlert[]
			{
				CreateModel(() => new
				{
					AlertID  = 1234,
					Code     = 5,
					Source   = "Hardware",
					Title    = "Something bad is happening",
					Severity = "Minor",
					Created  = DateTime.Now.AddHours(-2)
				}),
				CreateModel(() => new
				{
					Code         = 20,
					Source       = "Something",
					Title        = "A very bad thing happened",
					Severity     = "Major",
					Created      = DateTime.Now,
					AlertMessage = "A very bad thing happened to something.\nYou should do something about this."
				}),
				CreateModel(() => new
				{
					AlertID      = 500,
					Code         = 100,
					Source       = "Something",
					Severity     = "No Impact",
					Created      = DateTime.Today.AddDays(-10),
					Archived     = true,
					ArchivedDate = DateTime.Today.AddDays(-8)
				})
			};

			return data.Select(x => new object[] {x});
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void SerializeWithWritableProperties(IAlert item)
		{
			TestThatWritablePropertiesAreSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void SerializeWithoutReadOnlyProperties(IAlert item)
		{
			TestThatReadonlyPropertiesAreNotSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonTestParams))]
		public void DeserializeWithAlertID(IAlert item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.AlertID,
				item.AlertID + 5678);
		}
		

	}
}
