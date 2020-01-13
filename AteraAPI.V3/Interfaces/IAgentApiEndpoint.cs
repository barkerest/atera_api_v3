using System.Collections.Generic;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API interface for agents.
	/// </summary>
	public interface IAgentApiEndpoint : IReadDeleteApiEndpoint<IAgent, int>
	{
		/// <summary>
		/// Gets all the agents for the specified customer.
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		IEnumerable<IAgent> FindByCustomer(int customerId);

		/// <summary>
		/// Gets all the agents for the specified machine name.
		/// </summary>
		/// <param name="machineName"></param>
		/// <returns></returns>
		IEnumerable<IAgent> FindByMachine(string machineName);
	}
}
