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
				CreateModel(m =>
				            {
					            m.CustomerID = 12;
					            m.FirstName  = "George";
					            m.LastName   = "Jetson";
					            m.Email      = "gjetson@spacely.com";
				            },
				            ("CreatedOn", DateTime.Now.AddHours(-1)),
				            ("LastModified", DateTime.Now)),
				CreateModel(m =>
				            {
					            m.CustomerName = "Slate Rock and Gravel Company";
					            m.FirstName = "Fred";
					            m.LastName = "Flintstone";
					            m.Email = "fflintstone@slate.com";
					            m.IsContactPerson = true;
				            },
				            ("ContactID", 1234),
				            ("CreatedOn", DateTime.Now.AddHours(-1)),
				            ("LastModified", DateTime.Now))
			};

			return data.Select(x => new object[] {x});
		}

		private void AdjustConditionals(bool serialize)
		{
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
			Assert.NotNull(item);
			AdjustConditionals(item.ContactID == 0);
			var jo = JObject.FromObject(item);
			foreach (var p in Properties.Where(x => x.Serialize))
			{
				Assert.True(jo.ContainsKey(p.Name), $"Missing {p.Name} property.");
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithoutReadonlyProperties(IContact item)
		{
			Assert.NotNull(item);
			AdjustConditionals(item.ContactID == 0);
			var jo = JObject.FromObject(item);
			foreach (var p in Properties.Where(x => !x.Serialize))
			{
				Assert.False(jo.ContainsKey(p.Name), $"Contains {p.Name} property.");
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithContactID(IContact item)
		{
			Assert.NotNull(item);
			var newId = item.ContactID + 5678;
			
			Assert.NotEqual(item.ContactID, newId);
			var jo = JObject.FromObject(item);
			Assert.False(jo.ContainsKey("EndUserID"));
			jo["EndUserID"] = new JValue(newId);
			Assert.True(jo.ContainsKey("EndUserID"));

			var type = InternalModel.TypeFor(typeof(IContact));
			var newItem = jo.ToObject(type) as IContact;
			Assert.NotNull(newItem);
			Assert.Equal(newId, newItem.ContactID);
			Assert.NotEqual(item.ContactID, newItem.ContactID);
		}
		

	}
}
