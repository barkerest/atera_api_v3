using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class ContractApiEndpoint : CommonApiEndpointBase<IContract, Contract>, IContractApiEndpoint
	{
		internal ContractApiEndpoint(ApiContext context) 
			: base(context, "contracts", m => m.ContractID)
		{
		}

		public IEnumerable<IContract> FindByCustomer(int customerId) => CommonGetEnumerable($"{_name}/customer/{customerId}");

		public Task<IEnumerable<IContract>> FindByCustomerAsync(int customerId) => CommonGetEnumerableAsync($"{_name}/customer/{customerId}");
	}
}
