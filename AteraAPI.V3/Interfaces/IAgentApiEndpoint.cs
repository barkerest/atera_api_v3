using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for agents.
	/// </summary>
	public interface IAgentApiEndpoint : IReadDeleteApiEndpoint<IAgent>
	{
		/// <summary>
		/// Gets all the agents for the specified customer.
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		IEnumerable<IAgent> FindByCustomer(int customerId);
		
		/// <summary>
		/// Gets all the agents for the specified customer.
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		Task<IEnumerable<IAgent>> FindByCustomerAsync(int customerId);

		/// <summary>
		/// Gets all the agents for the specified machine name.
		/// </summary>
		/// <param name="machineName"></param>
		/// <returns></returns>
		IEnumerable<IAgent> FindByMachine(string machineName);
		
		/// <summary>
		/// Gets all the agents for the specified machine name.
		/// </summary>
		/// <param name="machineName"></param>
		/// <returns></returns>
		Task<IEnumerable<IAgent>> FindByMachineAsync(string machineName);
	}
}
