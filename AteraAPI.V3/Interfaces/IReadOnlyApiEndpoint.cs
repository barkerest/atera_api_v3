using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Common functionality for a read-only API endpoint.
	/// </summary>
	/// <typeparam name="TInterface"></typeparam>
	public interface IReadOnlyApiEndpoint<TInterface> : IEnumerable<TInterface>
		where TInterface : class
	{
		/// <summary>
		/// Finds the item with the specified ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TInterface Find(int id);

		/// <summary>
		/// Finds the item with the specified ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<TInterface> FindAsync(int id);

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
}
