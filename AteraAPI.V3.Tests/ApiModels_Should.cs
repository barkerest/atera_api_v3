using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AteraAPI.V3.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace AteraAPI.V3.Tests
{
	public class ApiModels_Should
	{
		private static Type ApiModelTypeBase { get; } = typeof(IApiModel);
		private static Assembly Lib { get; } = typeof(IApiModel).Assembly;

		private static IReadOnlyList<Type> ApiModelInterfaces { get; }
			= Lib.GetExportedTypes().Where(x => x.IsInterface && x != ApiModelTypeBase && ApiModelTypeBase.IsAssignableFrom(x)).OrderBy(x => x.Name).ToArray();

		private static IReadOnlyDictionary<Type, Type[]> ApiModelImplementations { get; }
			= ApiModelInterfaces.ToDictionary(x => x, x => Lib.GetTypes().Where(y => !y.IsInterface && !y.IsAbstract && y.IsClass && x.IsAssignableFrom(y)).OrderBy(y => y.Name).ToArray());

		private readonly ITestOutputHelper _output;
		
		public ApiModels_Should(ITestOutputHelper output)
		{
			_output = output ?? throw new ArgumentNullException();
		}
		
		[Fact]
		public void HaveOneImplementation()
		{
			var badImps = ApiModelImplementations.Where(x => x.Value is null || x.Value.Length != 1).ToArray();

			foreach (var imp in badImps)
			{
				_output.WriteLine($"Type {imp.Key} has {imp.Value?.Length ?? 0} implementations.");
			}
			
			Assert.Empty(badImps);
		}
		
		[Fact]
		public void OverrideToString()
		{
			var imps = ApiModelImplementations.Where(x => x.Value != null && x.Value.Length == 1).Select(x => new { Interface = x.Key, Implementation = x.Value[0] }).ToArray();
			var failed = false;

			foreach (var imp in imps)
			{
				var method = imp.Implementation.GetMethod("ToString", BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy, null, Type.EmptyTypes, null);
				if (method is null)
				{
					failed = true;
					_output.WriteLine($"Type {imp.Implementation} is missing ToString.");
				}
				else if (method.DeclaringType != imp.Implementation)
				{
					failed = true;
					_output.WriteLine($"Type {imp.Implementation} does not override ToString.");
				}
			}
			
			Assert.False(failed);
		}

		[Fact]
		public void OverrideEquals()
		{
			var imps   = ApiModelImplementations.Where(x => x.Value != null && x.Value.Length == 1).Select(x => new { Interface = x.Key, Implementation = x.Value[0] }).ToArray();
			var failed = false;

			foreach (var imp in imps)
			{
				var method = imp.Implementation.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy, null, new[] {typeof(object)}, null);
				if (method is null)
				{
					failed = true;
					_output.WriteLine($"Type {imp.Implementation} is missing Equals.");
				}
				else if (method.DeclaringType != imp.Implementation)
				{
					failed = true;
					_output.WriteLine($"Type {imp.Implementation} does not override Equals.");
				}
			}
			
			Assert.False(failed);
		}

		[Fact]
		public void NotBePublic()
		{
			var imps   = ApiModelImplementations.Where(x => x.Value != null && x.Value.Length == 1).Select(x => new { Interface = x.Key, Implementation = x.Value[0] }).ToArray();
			var failed = false;

			foreach (var imp in imps)
			{
				if (imp.Implementation.IsPublic)
				{
					failed = true;
					_output.WriteLine($"Type {imp.Implementation} should not be public.");
				}
			}
			
			Assert.False(failed);
		}

		[Fact]
		public void HaveReadWriteProperties()
		{
			var imps   = ApiModelImplementations.Where(x => x.Value != null && x.Value.Length == 1).Select(x => new { Interface = x.Key, Implementation = x.Value[0] }).ToArray();
			var failed = false;

			foreach (var imp in imps)
			{
				var propsToCheck = imp.Interface.GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(x => x.Name).ToArray();
				foreach (var propToCheck in propsToCheck)
				{
					var prop = imp.Implementation.GetProperty(propToCheck.Name, BindingFlags.Public | BindingFlags.Instance);
					if (prop is null)
					{
						_output.WriteLine($"Type {imp.Implementation} is missing {propToCheck.Name} property.");
						failed = true;
					}
					else if (!prop.CanWrite || !prop.CanRead)
					{
						_output.WriteLine($"Type {imp.Implementation} does not have a read/write {prop.Name} property.");
						failed = true;
					}
				}
			}
			
			Assert.False(failed);
		}
	}
}
