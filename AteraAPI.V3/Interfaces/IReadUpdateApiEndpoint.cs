using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Common functionality for a read-update API endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	public interface IReadUpdateApiEndpoint<TInterface> : IReadOnlyApiEndpoint<TInterface>
		where TInterface : class
	{
		/// <summary>
		/// Updates the item and returns true on success.
		/// </summary>
		/// <param name="id">The ID of the item to update.</param>
		/// <param name="item">The item to update.</param>
		/// <returns></returns>
		bool Update(int id, TInterface item);

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
		Task<bool> UpdateAsync(int id, TInterface item);

		/// <summary>
		/// Updates the item (using the ID from the item) and returns true on success.
		/// </summary>
		/// <param name="item">The item to update.</param>
		/// <returns></returns>
		Task<bool> UpdateAsync(TInterface item);
	}
}
