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

		/// <summary>
		/// Gets the API model interface for this model.
		/// </summary>
		/// <param name="model">The API model to get the interface for.</param>
		/// <returns></returns>
		public static Type GetApiModelTypeDeclaration(this IApiModel model)
		{
			return model?.GetType().GetApiModelTypeDeclaration() ?? null;
		}
		
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
		
		private static readonly IReadOnlyDictionary<long,string> BinarySizes = new Dictionary<long, string>()
		{
			{1L<<60, "EiB" },
			{1L<<50, "PiB"},
			{1L<<40, "TiB"},
			{1L<<30, "GiB"},
			{1L<<20, "MiB"},
			{1L<<10, "KiB"},
		};

		private static string ToStringDataSize(this long bytes)
		{
			if (bytes < 0) throw new ArgumentOutOfRangeException();
			
			foreach (var size in BinarySizes.Keys.OrderByDescending(x => x))
			{
				if (bytes > size)
				{
					var bsz = (double) bytes / (double) size;
					return $"{bsz:#,##0.00} {BinarySizes[size]}";
				}
			}

			return $"{bytes} B";
		}

		/// <summary>
		/// Gets the total size of the disk in a user friendly format.
		/// </summary>
		/// <param name="disk"></param>
		/// <returns></returns>
		public static string FriendlyTotalSize(this IHardwareDisk disk)
		{
			return disk?.Total?.ToStringDataSize() ?? "";
		}

		/// <summary>
		/// Gets the used size of the disk in a user friendly format.
		/// </summary>
		/// <param name="disk"></param>
		/// <returns></returns>
		public static string FriendlyUsedSize(this IHardwareDisk disk)
		{
			return disk?.Used?.ToStringDataSize() ?? "";
		}

		/// <summary>
		/// Gets the free size of the disk in a user friendly format.
		/// </summary>
		/// <param name="disk"></param>
		/// <returns></returns>
		public static string FriendlyFreeSize(this IHardwareDisk disk)
		{
			return disk?.Free?.ToStringDataSize() ?? "";
		}
		
	}
}
