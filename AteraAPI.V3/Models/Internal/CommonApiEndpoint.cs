using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	/// <summary>
	/// A common endpoint for CRUD operations.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	/// <typeparam name="TModel"></typeparam>
	internal class CommonApiEndpoint<TInterface, TModel> : ICommonApiEndpoint<TInterface> 
		where TInterface : class 
		where TModel : class, TInterface
	{
		private readonly IApiContextInternal _context;
		private readonly string _name;
		private readonly Func<TInterface, int> _getId;
		
		internal CommonApiEndpoint(ApiContext context, string endpointName, bool canCreate, bool canUpdate, bool canDelete, Func<TInterface, int> getId)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_name = endpointName ?? throw new ArgumentNullException(nameof(endpointName));
			if (string.IsNullOrEmpty(_name)) throw new ArgumentException("Cannot be blank.", nameof(endpointName));
			_getId = getId ?? throw new ArgumentNullException(nameof(getId));
			CanCreate = canCreate;
			CanUpdate = canUpdate;
			CanDelete = canDelete;
		}

		/// <inheritdoc />
		public bool CanCreate { get; }

		/// <inheritdoc />
		public bool CanUpdate { get; }

		/// <inheritdoc />
		public bool CanDelete { get; }

		/// <inheritdoc />
		public async Task<TInterface> FindAsync(int id)
			=> await _context.ExecuteAsync<TModel>($"{_name}/{id}");

		/// <inheritdoc />
		public async Task<int> CreateAsync(TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			if (!CanCreate) throw new NotSupportedException();
			var result = await _context.ExecuteAsync<UpdateItemResult>(_name, data: item, method: "POST", expectedStatusCode: HttpStatusCode.Created);
			return result?.ActionID ?? 0;
		}

		/// <inheritdoc />
		public async Task<bool> UpdateAsync(int id, TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			if (!CanUpdate) throw new NotSupportedException();
			var result = await _context.ExecuteAsync<UpdateItemResult>($"{_name}/{id}", data: item, method: "POST", expectedStatusCode: HttpStatusCode.OK);
			return (result?.ActionID ?? 0) == id;
		}

		/// <inheritdoc />
		public Task<bool> UpdateAsync(TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			return UpdateAsync(_getId(item), item);
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAsync(int id)
		{
			if (!CanDelete) throw new NotSupportedException();
			await _context.ExecuteAsync($"{_name}/{id}", method: "DELETE", expectedStatusCode: HttpStatusCode.NoContent);
			return true;
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(TInterface item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			return DeleteAsync(_getId(item));
		}

		/// <inheritdoc />
		public async Task<int> GetCountAsync()
		{
			var tmp = await _context.ExecuteAsync<GetListResult<TModel>>(_name, new[] {("page", "1"), ("itemsInPage", "1")});
			return tmp?.TotalItemCount ?? 0;
		}
				
		/// <inheritdoc />
		public int GetCount() => GetCountAsync().Result;

		/// <inheritdoc />
		public TInterface Find(int id) => FindAsync(id).Result;

		/// <inheritdoc />
		public int Create(TInterface item) => CreateAsync(item).Result;

		/// <inheritdoc />
		public bool Update(int id, TInterface item) => UpdateAsync(id, item).Result;

		/// <inheritdoc />
		public bool Update(TInterface item) => UpdateAsync(item).Result;

		/// <inheritdoc />
		public bool Delete(int id) => DeleteAsync(id).Result;

		/// <inheritdoc />
		public bool Delete(TInterface item) => DeleteAsync(item).Result;

		/// <inheritdoc />
		public IEnumerator<TInterface> GetEnumerator()
		{
			var pp = ("itemsInPage", "100");
			var pg = 1;
			var result = _context.ExecuteAsync<GetListResult<TModel>>(_name, new[] {("page", pg.ToString()), pp}).Result;
			while (result.Page < result.TotalPages)
			{
				foreach (var item in result.Items)
				{
					yield return item;
				}

				pg++;
				result = _context.ExecuteAsync<GetListResult<TModel>>(_name, new[] {("page", pg.ToString()), pp}).Result;
			}
		}

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
