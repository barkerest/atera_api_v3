using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace AteraAPI.V3.Tests.Models
{
	public abstract class Model_Should<TInterface> where TInterface : class
	{
		protected class PropInfo
		{
			public PropertyInfo Property    { get; set; }
			public string       Name        { get; set; }
			public bool         Serialize   { get; set; }
			public bool         Deserialize { get; set; }
		}

		protected Type                    InterfaceType { get; } = typeof(TInterface);
		protected Type                    ModelType     { get; }
		protected IReadOnlyList<PropInfo> Properties    { get; }

		protected Model_Should()
		{
			ModelType = InternalModel.TypeFor(InterfaceType);
			Properties = InterfaceType
			             .GetProperties(BindingFlags.Public | BindingFlags.Instance)
			             .OrderBy(x => x.Name)
			             .Select(x => new PropInfo() {Property = x})
			             .ToArray();

			foreach (var p in Properties)
			{
				var sib  = ModelType.GetProperty(p.Property.Name);
				var attr = sib?.GetCustomAttribute<JsonPropertyAttribute>();
				p.Name        = attr?.PropertyName ?? p.Property.Name;
				p.Deserialize = p.Property.CanRead && (sib.GetCustomAttribute<JsonIgnoreAttribute>() is null);
				p.Serialize   = p.Deserialize && p.Property.CanWrite;
			}
		}

		
		protected static TInterface CreateModel(Action<TInterface> config, params (string, object)[] properties)
		{
			if (config is null) config = m => { };
			var ret = InternalModel.CreateInstanceOf<TInterface>(properties);
			config(ret);
			return ret;
		}

		protected static TInterface CreateModel(params (string, object)[] properties) => CreateModel(m => { }, properties);
	}
}
