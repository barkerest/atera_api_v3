using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public class Customer_Should : Model_Should<ICustomer>
	{

		public static IEnumerable<object[]> GetJsonConvertTestParams()
		{
			var data = new ICustomer[]
			{
				CreateModel(m =>
				            {
					            m.CustomerName = "Customer 1";
					            m.City         = "Cleveland";
				            },
				            ("CustomerID", 1234),
				            ("CreatedOn", DateTime.Now.AddHours(-1)),
				            ("LastModified", DateTime.Now)),
				CreateModel(m =>
				            {
					            m.CustomerName = "Customer 2";
					            m.City         = "Pittsburgh";
				            },
				            ("CustomerID", 4321),
				            ("CreatedOn", DateTime.Now.AddDays(-1)),
				            ("LastModified", DateTime.Now.AddHours(-8))),
			};
			
			return  data.Select(x => new object[] {x});
		}

		
		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithWritableProperties(ICustomer item)
		{
			Assert.NotNull(item);
			var jo = JObject.FromObject(item);
			foreach (var p in Properties.Where(x => x.Serialize))
			{
				Assert.True(jo.ContainsKey(p.Name), $"Missing {p.Name} property.");
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithoutReadonlyProperties(ICustomer item)
		{
			Assert.NotNull(item);
			var jo = JObject.FromObject(item);
			foreach (var p in Properties.Where(x => !x.Serialize))
			{
				Assert.False(jo.ContainsKey(p.Name), $"Contains {p.Name} property.");
			}
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithCustomerID(ICustomer item)
		{
			var newId = item.CustomerID + 5678;
			
			Assert.NotNull(item);
			Assert.NotEqual(item.CustomerID, newId);
			var jo = JObject.FromObject(item);
			Assert.False(jo.ContainsKey("CustomerID"));
			jo["CustomerID"] = new JValue(newId);
			Assert.True(jo.ContainsKey("CustomerID"));

			var type = InternalModel.TypeFor(typeof(ICustomer));
			var obj = jo.ToObject(type);
			var newItem = obj as ICustomer;
			
			Assert.NotNull(newItem);
			Assert.Equal(newId, newItem.CustomerID);
			Assert.NotEqual(item.CustomerID, newItem.CustomerID);
		}
	}
}
