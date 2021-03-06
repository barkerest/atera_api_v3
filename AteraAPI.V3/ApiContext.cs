﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using AteraAPI.V3.Exceptions;
using AteraAPI.V3.Interfaces;
using AteraAPI.V3.Models.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AteraAPI.V3
{
	/// <summary>
	/// Represents an API context.
	/// </summary>
	public class ApiContext : IApiContextInternal
	{
		/// <summary>
		/// The base URL for the API.
		/// </summary>
		public string ApiBaseUrl { get; }
		
		/// <summary>
		/// The API key.
		/// </summary>
		public string ApiKey { get; }

		/// <summary>
		/// Creates a new context using the supplied settings.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public ApiContext(string apiBaseUrl, string apiKey)
		{
			ApiBaseUrl = apiBaseUrl ?? throw new ArgumentNullException(nameof(apiBaseUrl));
			ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
			if (string.IsNullOrWhiteSpace(ApiBaseUrl)) throw new ArgumentException("Cannot be blank.", nameof(apiBaseUrl));
			if (string.IsNullOrWhiteSpace(ApiKey)) throw new ArgumentException("Cannot be blank.", nameof(apiKey));
			
			if (!ApiBaseUrl.EndsWith("/")) ApiBaseUrl += "/";

			Customers = new CustomerApiEndpoint(this);
			Contacts = new ContactApiEndpoint(this);
			Agents = new AgentApiEndpoint(this);
			Alerts = new AlertApiEndpoint(this);
			Invoices = new InvoiceApiEndpoint(this);
			ProductRates = new RateApiEndpoint(this, "products");
			ExpenseRates = new RateApiEndpoint(this, "expenses");
			Contracts = new ContractApiEndpoint(this);
			KnowledgeBase = new KnowledgeBaseApiEndpoint(this);
			Tickets = new TicketApiEndpoint(this);
			CustomValues = new CustomValueApiEndpoint(this);
		}

		/// <summary>
		/// Creates a new context using the supplied API key and the default base URL.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public ApiContext(string apiKey) : this("https://app.atera.com/api/v3/", apiKey)
		{
			
		}
		
		/// <summary>
		/// Creates, reads, updates, and deletes customers.
		/// </summary>
		public ICustomerApiEndpoint Customers { get; }

		/// <summary>
		/// Creates, reads, updates, and deletes contacts.
		/// </summary>
		public IContactApiEndpoint Contacts { get; }
		
		/// <summary>
		/// Reads and deletes agents.
		/// </summary>
		public IAgentApiEndpoint Agents { get; }

		/// <summary>
		/// Creates, reads, and deletes alerts.
		/// </summary>
		public IAlertApiEndpoint Alerts { get; }
		
		/// <summary>
		/// Reads invoices.
		/// </summary>
		public IInvoiceApiEndpoint Invoices { get; }
		
		/// <summary>
		/// Creates, reads, updates, and deletes products.
		/// </summary>
		public IRateApiEndpoint ProductRates { get; }
		
		/// <summary>
		/// Creates, reads, updates, and deletes expenses.
		/// </summary>
		public IRateApiEndpoint ExpenseRates { get; }
		
		/// <summary>
		/// Reads contracts.
		/// </summary>
		public IContractApiEndpoint Contracts { get; }
		
		/// <summary>
		/// Reads knowledge base entries.
		/// </summary>
		public IKnowledgeBaseApiEndpoint KnowledgeBase { get; }
		
		/// <summary>
		/// Creates, reads, updates, and deletes tickets.
		/// </summary>
		public ITicketApiEndpoint Tickets { get; }
		
		/// <summary>
		/// Gets custom values.
		/// </summary>
		public ICustomValueApiEndpoint CustomValues { get; }
		
		#region IApiContextInternal
		
		private HttpWebRequest CreateRequest(
			string endpoint,
			string method = "GET",
			IEnumerable<(string, string)> args = null)
		{
			string url = ApiBaseUrl + endpoint;

			if (args != null)
			{
				url += "?" + string.Join("&", args.Select(x => HttpUtility.UrlEncode(x.Item1) + "=" + HttpUtility.UrlEncode(x.Item2)));
				url =  url.TrimEnd('?');
			}

			var ret = (HttpWebRequest) WebRequest.Create(url);
			ret.Method = method;
			ret.Headers.Add("X-API-KEY", ApiKey);
			ret.Headers.Add("Accept", "application/json");

			return ret;
		}

		private async Task<string> GetResponseBody(HttpWebResponse response)
		{
			using (var stream = response.GetResponseStream())
			{
				if (stream is object)
				{
					using (var streamReader = new StreamReader(stream))
					{
						return await streamReader.ReadToEndAsync();
					}
				}
			}

			return "";
		}
		
		private JToken GetJObject(string body, Type t)
		{
			try
			{
				if (string.IsNullOrEmpty(body) || body.Trim().ToLower().Equals("null"))
				{
					return null;
				}
				
				using (var stringReader = new StringReader(body))
				using (var jsonReader = new JsonTextReader(stringReader))
				{
					if (t.IsArray)
					{
						return JArray.Load(jsonReader);
					}
					else
					{
						return JObject.Load(jsonReader);
					}
				}
			}
			catch (JsonException jsonException)
			{
				throw new ApiJsonException(body, jsonException);
			}
		}

		async Task<string> IApiContextInternal.ExecuteAsync(string endpoint, object data, IEnumerable<(string, string)> args, string method, HttpStatusCode expectedStatusCode)
		{
			var request = CreateRequest(endpoint, method, args);

			if (data != null)
			{
				request.Headers.Add("Content-Type", "application/json");
				using (var stream = await request.GetRequestStreamAsync())
				using (var streamWriter = new StreamWriter(stream))
				using (var jsonWriter = new JsonTextWriter(streamWriter))
				{
					await JObject.FromObject(data).WriteToAsync(jsonWriter);
				}
			}

			var response     = (HttpWebResponse) await request.GetResponseAsync();
			var responseBody = await GetResponseBody(response);

			if (response.StatusCode != expectedStatusCode)
			{
				throw new ApiHttpException(response.StatusCode, responseBody);
			}

			return responseBody;
		}

		async Task<TResult> IApiContextInternal.ExecuteAsync<TResult>(string endpoint, object data, IEnumerable<(string, string)> args, string method, HttpStatusCode expectedStatusCode)
		{
			var responseBody = await ((IApiContextInternal)this).ExecuteAsync(endpoint, data, args, method, expectedStatusCode);

			if (string.IsNullOrWhiteSpace(responseBody)) return null;

			var responseObject = GetJObject(responseBody, typeof(TResult));

			try
			{
				return responseObject?.ToObject<TResult>();					
			}
			catch (JsonException jsonException)
			{
				throw new ApiJsonException(responseBody, jsonException);
			}
		}
		
		#endregion
	}
}
