using System;
using System.Collections.Generic;
using System.Linq;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json.Linq;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Contact_Should : Model_Should<IContact>
	{
		public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var data = new IContact[]
			{
				CreateModel(() => new
				{
					CustomerID   = 12,
					FirstName    = "George",
					LastName     = "Jetson",
					Email        = "gjetson@spacely.com",
					CreatedOn    = DateTime.Now.AddHours(-1),
					LastModified = DateTime.Now
				}),
				CreateModel(() => new
				{
					ContactID       = 1234,
					CustomerName    = "Slate Rock and Gravel Company",
					FirstName       = "Fred",
					LastName        = "Flintstone",
					Email           = "fflintstone@slate.com",
					IsContactPerson = true,
					CreatedOn       = DateTime.Now.AddHours(-120),
					LastModified    = DateTime.Now.AddHours(-23)
				}),
			};

			return data.Select(x => new object[] {x});
		}


		protected override void AdjustProperties(IContact item)
		{
			var serialize = (item.ContactID == 0);
			foreach (var p in Properties)
			{
				if (p.Name == "CustomerID" || p.Name == "CustomerName" || p.Name == "Email")
				{
					p.Serialize = serialize;
				}
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithWritableProperties(IContact item)
		{
			TestThatWritablePropertiesAreSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithoutReadonlyProperties(IContact item)
		{
			TestThatReadonlyPropertiesAreNotSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithContactID(IContact item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.ContactID,
				item.ContactID + 5678);
		}
	}
}
