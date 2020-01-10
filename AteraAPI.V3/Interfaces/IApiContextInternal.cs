using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	internal interface IApiContextInternal
	{
		Task<string> ExecuteAsync(
			string                        endpoint,
			object                        data               = null,
			IEnumerable<(string, string)> args               = null,
			string                        method             = "GET",
			HttpStatusCode                expectedStatusCode = HttpStatusCode.OK);

		Task<TResult> ExecuteAsync<TResult>(
			string                        endpoint,
			object                        data               = null,
			IEnumerable<(string, string)> args               = null,
			string                        method             = "GET",
			HttpStatusCode                expectedStatusCode = HttpStatusCode.OK)
			where TResult : class;
	}
}
