using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace AteraAPI.V3.Tests.Models
{
	public abstract class Model_Should<TInterface> where TInterface : class
	{
		protected interface IPropInfo
		{
			PropertyInfo Property    { get; }
			string       Name        { get; }
			bool         Serialize   { get; set; }
			bool         Deserialize { get; }
		}

		private class PropInfo : IPropInfo
		{
			public PropertyInfo Property    { get; set; }
			public string       Name        { get; set; }
			public bool         Serialize   { get; set; }
			public bool         Deserialize { get; set; }
		}

		protected Type                     InterfaceType { get; } = typeof(TInterface);
		protected Type                     ModelType     { get; }
		protected IReadOnlyList<IPropInfo> Properties    { get; }

		/// <summary>
		/// Override to include a standard way to change the Serialize attribute on the properties.
		/// </summary>
		/// <param name="item"></param>
		protected virtual void AdjustProperties(TInterface item)
		{
		}

		protected Model_Should()
		{
			ModelType = InternalModel.TypeFor(InterfaceType);
			var tmp = InterfaceType
			             .GetProperties(BindingFlags.Public | BindingFlags.Instance)
			             .OrderBy(x => x.Name)
			             .Select(x => new PropInfo() {Property = x})
			             .ToArray();

			foreach (var p in tmp)
			{
				var sib  = ModelType.GetProperty(p.Property.Name);
				var attr = sib?.GetCustomAttribute<JsonPropertyAttribute>();
				p.Name        = attr?.PropertyName ?? p.Property.Name;
				p.Deserialize = p.Property.CanRead && (sib.GetCustomAttribute<JsonIgnoreAttribute>() is null);
				p.Serialize   = p.Deserialize && p.Property.CanWrite;
			}

			Properties = tmp.Cast<IPropInfo>().ToArray();
		}

		/// <summary>
		/// Use to create a model instance.
		/// </summary>
		/// <param name="properties">Defines the properties to set in the model instance.  Allows properties to be set in the instance that are read-only in the interface provided the implementation is read-write.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		protected static TInterface CreateModel(Expression<Func<object>> properties)
		{
			var nex = properties.Body as NewExpression;
			if (nex is null) throw new ArgumentException("Must be a new object expression.");
			
			if (nex.Members is null || nex.Members.Count < 1) throw new ArgumentException("Must provide at least one member to set.");

			var propReaders = nex.Members.OfType<PropertyInfo>().ToArray();
			if (propReaders is null || propReaders.Length < 1) throw new ArgumentException("Must provide at least one property to set.");

			var obj = properties.Compile().Invoke();
			if (obj is null) throw new ArgumentException("Must generate a valid object from the new object expression.");

			var props = propReaders.Select(x => (x.Name.ToString(), x.GetValue(obj))).ToArray();

			var ret = InternalModel.CreateInstanceOf<TInterface>(props);
			return ret;
		}

		private static PropertyInfo GetPropertyInfo(LambdaExpression expression)
		{
			var mex = expression.Body as MemberExpression;
			if (mex is null 
			    && expression.Body is UnaryExpression uex 
			    && uex.NodeType == ExpressionType.Convert)
			{
				mex = uex.Operand as MemberExpression;
			}

			if (mex is null) throw new ArgumentException("Requires a member expression.");

			return mex.Member as PropertyInfo ?? throw new ArgumentException("Requires a property in the member expression.");
		}

		/// <summary>
		/// Tests that all properties expected to be serialized are serialized.
		/// </summary>
		/// <param name="item"></param>
		/// <remarks>
		/// Default is to serialize all properties that are read-write in the interface.
		/// Use AdjustProperties to change this on case-by-case basis.
		/// </remarks>
		protected void TestThatWritablePropertiesAreSerialized(TInterface item)
		{
			Assert.NotNull(item);
			AdjustProperties(item);
			var jo = JObject.FromObject(item);
			foreach (var p in Properties.Where(x => x.Serialize))
			{
				Assert.True(jo.ContainsKey(p.Name), $"Missing {p.Name} property.");
			}
		}

		/// <summary>
		/// Tests that all properties expected to not be serialized are not serialized.
		/// </summary>
		/// <param name="item"></param>
		/// <remarks>
		/// Default is to not serialize all properties that are read-only in the interface.
		/// Use AdjustProperties to change this on a case-by-case basis.
		/// </remarks>
		protected void TestThatReadonlyPropertiesAreNotSerialized(TInterface item)
		{
			Assert.NotNull(item);
			AdjustProperties(item);
			var jo = JObject.FromObject(item);
			foreach (var p in Properties.Where(x => !x.Serialize))
			{
				Assert.False(jo.ContainsKey(p.Name), $"Contains {p.Name} property.");
			}
		}

		/// <summary>
		/// Tests that a specific property is deserialized correctly.
		/// </summary>
		/// <param name="item">The item containing the current value.</param>
		/// <param name="property">The property to inspect.</param>
		/// <param name="testValue">The test value, must not match the current value.</param>
		/// <typeparam name="TValue"></typeparam>
		protected void TestThatPropertyIsDeserialized<TValue>(TInterface item, Expression<Func<TInterface, TValue>> property, TValue testValue)
		{
			// params cannot be null.
			Assert.NotNull(item);
			Assert.NotNull(property);
			
			// member expression must be a property expression.
			var prop = GetPropertyInfo(property);
			Assert.NotNull(prop);

			AdjustProperties(item);
			
			// property must be in the list of deserialized properties
			var propInfo = Properties.FirstOrDefault(x => x.Deserialize && x.Property.Name == prop.Name);
			Assert.NotNull(propInfo);
			
			// test value must differ from current value.
			Assert.NotEqual(testValue, prop.GetValue(item));

			var jo = JObject.FromObject(item);

			if (propInfo.Serialize)
			{
				// property should be in serialized JSON.
				Assert.True(jo.ContainsKey(propInfo.Name));
			}
			else
			{
				// property should not be in serialized JSON.
				Assert.False(jo.ContainsKey(propInfo.Name));
			}
			
			// set property in serialized JSON.
			jo[propInfo.Name] = new JValue(testValue);
			Assert.True(jo.ContainsKey(propInfo.Name));

			// deserialize the object.
			var type = InternalModel.TypeFor(typeof(TInterface));
			var newItem = jo.ToObject(type) as TInterface;
			Assert.NotNull(newItem);

			// the new object should have the test value.
			Assert.Equal(testValue, prop.GetValue(newItem));
			
			// the original object should not.
			Assert.NotEqual(testValue, prop.GetValue(item));
		}
		
	}
}
