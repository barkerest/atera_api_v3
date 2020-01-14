using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Common functionality for a read-delete API endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	public interface IReadDeleteApiEndpoint<TInterface> : IReadOnlyApiEndpoint<TInterface>
		where TInterface : class
	{
		/// <summary>
		/// Removes the item and returns true on success.
		/// </summary>
		/// <param name="id">The ID of the item to remove.</param>
		/// <returns>Returns true if the item is removed or does not exist.</returns>
		bool Delete(int id);

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
		Task<bool> DeleteAsync(int id);

		/// <summary>
		/// Removes the item (using the ID from the item).
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns></returns>
		Task<bool> DeleteAsync(TInterface item);
	}
}
