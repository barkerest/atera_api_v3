using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class CommonApiEndpointBase<TInterface, TModel> : IReadOnlyApiEndpoint<TInterface>
		where TInterface : class, IApiModel
		where TModel : class, TInterface
	{
		protected readonly IApiContextInternal   _context;
		protected readonly string                _name;
		protected readonly Func<TInterface, int> _getId;

		internal CommonApiEndpointBase(ApiContext context, string endpointName, Func<TInterface, int> getId)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_name    = endpointName ?? throw new ArgumentNullException(nameof(endpointName));
			if (string.IsNullOrEmpty(_name)) throw new ArgumentException("Cannot be blank.", nameof(endpointName));
			_getId    = getId ?? throw new ArgumentNullException(nameof(getId));
		}

		protected IEnumerable<TI> CommonGetEnumerable<TI,TM>(string name) where TM : class, TI where TI : IApiModel
		{
			var pp     = ("itemsInPage", "100");
			var pg     = 1;
			var result = _context.ExecuteAsync<GetListResult<TM>>(name, args: new[] {("page", pg.ToString()), pp}).Result;
			while (result.Page <= result.TotalPages)
			{
				foreach (var item in result.Items)
				{
					yield return item;
				}

				pg++;
				result = _context.ExecuteAsync<GetListResult<TM>>(name, args: new[] {("page", pg.ToString()), pp}).Result;
			}
		}

		protected IEnumerable<TInterface> CommonGetEnumerable(string name) => CommonGetEnumerable<TInterface, TModel>(name);
		
		protected async Task<IEnumerable<TI>> CommonGetEnumerableAsync<TI,TM>(string name) where TM : class, TI where TI : IApiModel
		{
			var pp     = ("itemsInPage", "100");
			var pg     = 1;
			var result = await _context.ExecuteAsync<GetListResult<TM>>(name, args: new[] {("page", pg.ToString()), pp});
			var ret = new List<TI>();
			
			while (result.Page <= result.TotalPages)
			{
				ret.AddRange(result.Items);
				
				pg++;
				result = await _context.ExecuteAsync<GetListResult<TM>>(name, args: new[] {("page", pg.ToString()), pp});
			}

			return ret;
		}

		protected Task<IEnumerable<TInterface>> CommonGetEnumerableAsync(string name) => CommonGetEnumerableAsync<TInterface, TModel>(name);

		public virtual IEnumerator<TInterface> GetEnumerator() => CommonGetEnumerable(_name).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		
		public virtual async Task<TInterface> FindAsync(int id)
			=> await _context.ExecuteAsync<TModel>($"{_name}/{id}");

		public virtual TInterface Find(int id) => FindAsync(id).Result;

		protected async Task<int> CommonGetCountAsync(string name)
		{
			var tmp = await _context.ExecuteAsync<GetListResult<TModel>>(name, args: new[] {("page", "1"), ("itemsInPage", "1")});
			return tmp?.TotalItemCount ?? 0;
		}

		public virtual Task<int> GetCountAsync() => CommonGetCountAsync(_name);
				
		public virtual int GetCount() => CommonGetCountAsync(_name).Result;
		
		
		protected async Task<int> CommonCreateAsync(TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			var result = await _context.ExecuteAsync<UpdateItemResult>(_name, data: item, method: "POST", expectedStatusCode: HttpStatusCode.Created);
			return result?.ActionID ?? 0;
		}

		protected async Task<bool> CommonUpdateAsync(int id, TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			var result = await _context.ExecuteAsync<UpdateItemResult>($"{_name}/{id}", data: item, method: "PUT", expectedStatusCode: HttpStatusCode.OK);
			return (result?.ActionID ?? 0) == id;
		}

		protected Task<bool> CommonUpdateAsync(TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			return CommonUpdateAsync(_getId(item), item);
		}

		protected async Task<bool> CommonDeleteAsync(int id)
		{
			await _context.ExecuteAsync($"{_name}/{id}", method: "DELETE", expectedStatusCode: HttpStatusCode.NoContent);
			return true;
		}

		protected Task<bool> CommonDeleteAsync(TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			return CommonDeleteAsync(_getId(item));
		}
	}
	
}
