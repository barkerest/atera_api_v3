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
	}
}
