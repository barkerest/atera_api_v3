using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class AgentApiEndpoint : CommonApiEndpointBase<IAgent, Agent>, IAgentApiEndpoint
	{
		internal AgentApiEndpoint(ApiContext context)
			: base(context, "agents", (m) => m.AgentID)
		{

		}

		public bool Delete(int id) => CommonDeleteAsync(id).Result;

		public bool Delete(IAgent item) => CommonDeleteAsync(item).Result;

		public Task<bool> DeleteAsync(int id) => CommonDeleteAsync(id);

		public Task<bool> DeleteAsync(IAgent item) => CommonDeleteAsync(item);

		public IEnumerable<IAgent> FindByCustomer(int customerId)
			=> CommonGetEnumerable($"{_name}/customer/{customerId}");

		public Task<IEnumerable<IAgent>> FindByCustomerAsync(int customerId)
			=> CommonGetEnumerableAsync($"{_name}/customer/{customerId}");

		public IEnumerable<IAgent> FindByMachine(string machineName)
			=> CommonGetEnumerable($"{_name}/machine/{HttpUtility.UrlEncode(machineName)}");

		public Task<IEnumerable<IAgent>> FindByMachineAsync(string machineName)
			=> CommonGetEnumerableAsync($"{_name}/machine/{HttpUtility.UrlEncode(machineName)}");
	}
}
