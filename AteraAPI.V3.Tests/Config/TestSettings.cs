using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Xunit.Sdk;

namespace AteraAPI.V3.Tests.Config
{
	public class TestSettings
	{
		private static IConfiguration _configuration;

		private static IConfiguration Configuration
		{
			get
			{
				if (_configuration != null) return _configuration;

				var config = ConfigPath();
				if (!File.Exists(config))
				{
					var example = config + ".example";
					if (File.Exists(example))
					{ 
						throw new XunitException("Need Configuration: Copy 'settings.json.example' to 'settings.json' and fill in the details.");
					}
					throw new XunitException("Need Configuration: Create 'settings.json' file.");
				}
			
				_configuration = new ConfigurationBuilder().AddJsonFile(config).Build();				
				
				return _configuration;
			}
		}
		
		
		private static string ConfigPath([CallerFilePath] string callerFilePath = "")
		{
			return Path.GetFullPath(Path.GetDirectoryName(callerFilePath).TrimEnd('\\', '/') + "/../settings.json");
		}

		
		private IDictionary<string, string> GetRequiredConfig(params string[] keys)
		{
			var errors = new List<string>();
			var ret    = new Dictionary<string,string>();

			foreach (var key in keys)
			{
				ret[key] = Configuration[key];
				if (string.IsNullOrWhiteSpace(ret[key]))
				{
					errors.Add($"The '{key}' value cannot be blank in 'testsettings.json'.");
				}
			}

			if (errors.Count > 0)
			{
				throw new XunitException(string.Join("\r\n", errors));
			}
			
			return ret;
		}

		public ApiContext GetApiContext()
		{
			var cfg = GetRequiredConfig("baseUrl", "apiKey");
			return new ApiContext(cfg["baseUrl"], cfg["apiKey"]);
		}
	}
}
