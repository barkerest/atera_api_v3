using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Common functionality for a read-only API endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	/// <typeparam name="TIdType"></typeparam>
	public interface IReadOnlyApiEndpoint<TInterface, TIdType> : IEnumerable<TInterface>
	{
		/// <summary>
		/// Finds the item with the specified ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TInterface Find(TIdType id);

		/// <summary>
		/// Finds the item with the specified ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<TInterface> FindAsync(TIdType id);

		/// <summary>
		/// Gets the number of items.
		/// </summary>
		/// <returns></returns>
		int GetCount();

		/// <summary>
		/// Gets the number of items.
		/// </summary>
		/// <returns></returns>
		Task<int> GetCountAsync();
	}

	/// <summary>
	/// Common functionality for a read-create endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	/// <typeparam name="TIdType"></typeparam>
	public interface IReadCreateApiEndpoint<TInterface, TIdType> : IReadOnlyApiEndpoint<TInterface, TIdType>
	{
		/// <summary>
		/// Creates the item and returns the ID on success.
		/// </summary>
		/// <param name="item">The item to create.</param>
		/// <returns></returns>
		TIdType Create(TInterface item);

		/// <summary>
		/// Creates the item and returns the ID on success.
		/// </summary>
		/// <param name="item">The item to create.</param>
		/// <returns></returns>
		Task<TIdType> CreateAsync(TInterface item);
	}

	/// <summary>
	/// Common functionality for a read-update API endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	/// <typeparam name="TIdType"></typeparam>
	public interface IReadUpdateApiEndpoint<TInterface, TIdType> : IReadOnlyApiEndpoint<TInterface, TIdType>
	{
		/// <summary>
		/// Updates the item and returns true on success.
		/// </summary>
		/// <param name="id">The ID of the item to update.</param>
		/// <param name="item">The item to update.</param>
		/// <returns></returns>
		bool Update(TIdType id, TInterface item);

		/// <summary>
		/// Updates the item (using the ID from the item) and returns true on success.
		/// </summary>
		/// <param name="item">The item to update.</param>
		/// <returns></returns>
		bool Update(TInterface item);

		/// <summary>
		/// Updates the item and returns true on success.
		/// </summary>
		/// <param name="id">The ID of the item to update.</param>
		/// <param name="item">The item to update.</param>
		/// <returns></returns>
		Task<bool> UpdateAsync(TIdType id, TInterface item);

		/// <summary>
		/// Updates the item (using the ID from the item) and returns true on success.
		/// </summary>
		/// <param name="item">The item to update.</param>
		/// <returns></returns>
		Task<bool> UpdateAsync(TInterface item);
	}

	/// <summary>
	/// Common functionality for a read-delete API endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	/// <typeparam name="TIdType"></typeparam>
	public interface IReadDeleteApiEndpoint<TInterface, TIdType> : IReadOnlyApiEndpoint<TInterface, TIdType>
	{
		/// <summary>
		/// Removes the item and returns true on success.
		/// </summary>
		/// <param name="id">The ID of the item to remove.</param>
		/// <returns>Returns true if the item is removed or does not exist.</returns>
		bool Delete(TIdType id);

		/// <summary>
		/// Removes the item (using the ID from the item).
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns></returns>
		bool Delete(TInterface item);

		/// <summary>
		/// Removes the item and returns true on success.
		/// </summary>
		/// <param name="id">The ID of the item to remove.</param>
		/// <returns>Returns true if the item is removed or does not exist.</returns>
		Task<bool> DeleteAsync(TIdType id);

		/// <summary>
		/// Removes the item (using the ID from the item).
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns></returns>
		Task<bool> DeleteAsync(TInterface item);
	}

	/// <summary>
	/// The interface used by common API endpoints to support CRUD operations.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	/// <typeparam name="TIdType"></typeparam>
	public interface ICommonApiEndpoint<TInterface, TIdType> :
		IReadCreateApiEndpoint<TInterface, TIdType>,
		IReadUpdateApiEndpoint<TInterface, TIdType>,
		IReadDeleteApiEndpoint<TInterface, TIdType>
	{
		/// <summary>
		/// Does this endpoint support adding new items.
		/// </summary>
		bool CanCreate { get; }

		/// <summary>
		/// Does this endpoint support editing items.
		/// </summary>
		bool CanUpdate { get; }

		/// <summary>
		/// Does this endpoint support removing items.
		/// </summary>
		bool CanDelete { get; }
	}

	/// <summary>
	/// The interface used by common API endpoints to support CRUD operations using integer IDs.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	public interface ICommonApiEndpoint<TInterface> : ICommonApiEndpoint<TInterface, int>
	{
		
	}
}
