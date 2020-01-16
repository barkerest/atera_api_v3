using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json.Linq;

namespace AteraAPI.V3.Extensions
{
	/// <summary>
	/// Defines some helper methods for the API.
	/// </summary>
	public static class ApiExtensions
	{
		private static readonly Dictionary<Type,Type> ApiModelTypeCache = new Dictionary<Type, Type>();
		
		internal static Type GetApiModelTypeDeclaration(this Type modelType)
		{
			if (modelType is null) throw new ArgumentNullException(nameof(modelType));
			
			lock (ApiModelTypeCache)
			{
				if (ApiModelTypeCache.ContainsKey(modelType)) return ApiModelTypeCache[modelType];
				
				var apiT = typeof(IApiModel);

				if (!apiT.IsAssignableFrom(modelType))
				{
					ApiModelTypeCache[modelType] = null;
					return null;
				}
				
				var apiInterfaces = modelType.GetInterfaces().Where(x => x != apiT && apiT.IsAssignableFrom(x)).ToArray();
				
				apiInterfaces = apiInterfaces.Except(apiInterfaces.SelectMany(x => x.GetInterfaces())).ToArray();
				
				if (modelType.BaseType != null)
				{
					// if there are any interfaces not found on the base type, use them.
					var tmpList = apiInterfaces.Except(modelType.BaseType.GetInterfaces()).ToArray();
					if (tmpList.Any())
					{
						apiInterfaces = tmpList;
					}
					else
					{
						var tmp = modelType.BaseType.GetApiModelTypeDeclaration();
						apiInterfaces = new[] {tmp};
					}
				}

				var returnType = apiInterfaces.FirstOrDefault();
				
				ApiModelTypeCache[modelType] = returnType;
				
				return returnType;
			}
		}

		internal static IEnumerable<PropertyInfo> GetInterfaceProperties(this Type interfaceType)
		{
			foreach (var prop in interfaceType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				yield return prop;
			}

			foreach (var ptype in interfaceType.GetInterfaces())
			{
				foreach (var prop in ptype.GetInterfaceProperties())
				{
					yield return prop;
				}
			}
		}
		
		
		
	}
}
