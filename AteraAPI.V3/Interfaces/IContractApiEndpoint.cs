using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for contracts.
	/// </summary>
	public interface IContractApiEndpoint : IReadOnlyApiEndpoint<IContract>
	{
		/// <summary>
		/// Finds contracts for the specified customer.
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		IEnumerable<IContract> FindByCustomer(int customerId);

		/// <summary>
		/// Finds contract for the specified customer.
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		Task<IEnumerable<IContract>> FindByCustomerAsync(int customerId);
	}
}
