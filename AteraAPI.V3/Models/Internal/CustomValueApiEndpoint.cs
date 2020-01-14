using System;
using System.Threading.Tasks;
using System.Web;
using AteraAPI.V3.Enums;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class CustomValueApiEndpoint : ICustomValueApiEndpoint
	{
		private readonly IApiContextInternal _context;
		private readonly string _name;

		internal CustomValueApiEndpoint(ApiContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_name = "customvalues";
		}

		public ICustomValue Find(string id) => FindAsync(id).Result;

		public async Task<ICustomValue> FindAsync(string id)
			=> await _context.ExecuteAsync<CustomValue>($"{_name}/{HttpUtility.UrlEncode(id)}");

		public ICustomValue FindFor(CustomFieldTarget targetType, int targetId, string fieldName)
			=> FindForAsync(targetType, targetId, fieldName).Result;

		public async Task<ICustomValue> FindForAsync(CustomFieldTarget targetType, int targetId, string fieldName)
			=> await _context.ExecuteAsync<CustomValue>($"{_name}/{targetType.ToString().ToLower()}field/{targetId}/{HttpUtility.UrlEncode(fieldName)}");
	}
}
