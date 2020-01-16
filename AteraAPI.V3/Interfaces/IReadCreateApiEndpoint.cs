using System;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Common functionality for a read-create endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	public interface IReadCreateApiEndpoint<TInterface> : IReadOnlyApiEndpoint<TInterface>
		where TInterface : class
	{
		/// <summary>
		/// Creates the item and returns the ID on success.
		/// </summary>
		/// <param name="item">The item to create.</param>
		/// <returns></returns>
		int Create(TInterface item);

		/// <summary>
		/// Creates the item and returns the ID on success.
		/// </summary>
		/// <param name="item">The item to create.</param>
		/// <returns></returns>
		Task<int> CreateAsync(TInterface item);

		/// <summary>
		/// Creates an item using the provided initialization method and returns the newly created item with the ID set on success..
		/// </summary>
		/// <param name="init">The method used to initialize the new item.</param>
		/// <returns></returns>
		TInterface Create(Action<TInterface> init);

		/// <summary>
		/// Creates an item using the provided initialization method and returns the newly created item with the ID set on success..
		/// </summary>
		/// <param name="init">The method used to initialize the new item.</param>
		/// <returns></returns>
		Task<TInterface> CreateAsync(Action<TInterface> init);
		
		/// <summary>
		/// Creates a new item instance that can be added to this collection.
		/// </summary>
		/// <returns></returns>
		TInterface NewItem();
	}
}
