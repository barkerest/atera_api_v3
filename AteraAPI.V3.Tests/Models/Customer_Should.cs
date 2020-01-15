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
				CreateModel(() => new
				{
					CustomerID   = 1234,
					CustomerName = "Customer 1",
					City         = "Cleveland",
					CreatedOn    = DateTime.Now.AddHours(-1),
					LastModified = DateTime.Now
				}),
				CreateModel(() => new
				{
					CustomerID   = 4321,
					CustomerName = "Customer 2",
					City         = "Pittsburgh",
					CreatedOn    = DateTime.Now.AddDays(-1),
					LastModified = DateTime.Now.AddHours(-8)
				}),
			};

			return data.Select(x => new object[] {x});
		}


		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithWritableProperties(ICustomer item)
		{
			TestThatWritablePropertiesAreSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void SerializeWithoutReadonlyProperties(ICustomer item)
		{
			TestThatReadonlyPropertiesAreNotSerialized(item);
		}

		[Theory]
		[MemberData(nameof(GetJsonConvertTestParams))]
		public void DeserializeWithCustomerID(ICustomer item)
		{
			TestThatPropertyIsDeserialized(
				item,
				x => x.CustomerID,
				item.CustomerID + 5678);
		}
	}
}
