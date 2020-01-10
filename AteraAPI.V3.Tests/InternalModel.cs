using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AteraAPI.V3.Tests
{
	public static class InternalModel
	{
		private static readonly Dictionary<Type, ConstructorInfo> Constructors = new Dictionary<Type, ConstructorInfo>();
		private static readonly Dictionary<Type, Type> Types = new Dictionary<Type, Type>();

		private static ConstructorInfo ConstructorFor(Type t)
		{
			lock (Constructors)
			{
				if (Constructors.ContainsKey(t)) return Constructors[t];
				Constructors[t] = t.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
				return Constructors[t];
			}
		}

		/// <summary>
		/// Gets the implementation type for the specified interface type.
		/// </summary>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static Type TypeFor(Type interfaceType)
		{
			lock (Constructors)
			{
				if (Types.ContainsKey(interfaceType)) return Types[interfaceType];

				foreach (var t in interfaceType.Assembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract))
				{
					if (interfaceType.IsAssignableFrom(t))
					{
						var c = t.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
						if (c != null)
						{
							Types[interfaceType] = t;
							Constructors[t] = c;
							return t;
						}
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Create an instance of an internal model from the API library and set properties that are exposed as read-only via the interface.
		/// </summary>
		/// <param name="properties"></param>
		/// <typeparam name="TInterface"></typeparam>
		/// <returns></returns>
		public static TInterface CreateInstanceOf<TInterface>(params (string, object)[] properties)
		{
			var t = TypeFor(typeof(TInterface));
			var c = ConstructorFor(t);
			var item = (TInterface)c.Invoke(null);

			foreach (var (name, value) in properties)
			{
				t.GetProperty(name)?.SetValue(item, value);
			}

			return item;
		}
		
	}
}
