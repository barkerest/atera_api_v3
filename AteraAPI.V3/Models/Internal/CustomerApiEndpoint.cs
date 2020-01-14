using System;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class CustomerApiEndpoint : CommonApiEndpointBase<ICustomer, Customer>, ICustomerApiEndpoint
	{
		internal CustomerApiEndpoint(ApiContext context) 
			: base(context, "customers", m => m.CustomerID)
		{
		}

		public int Create(ICustomer item) => CommonCreateAsync(item).Result;

		public Task<int> CreateAsync(ICustomer item) => CommonCreateAsync(item);

		public bool Update(int id, ICustomer item) => CommonUpdateAsync(id, item).Result;

		public bool Update(ICustomer item) => CommonUpdateAsync(item).Result;

		public Task<bool> UpdateAsync(int id, ICustomer item) => CommonUpdateAsync(id, item);

		public Task<bool> UpdateAsync(ICustomer item) => CommonUpdateAsync(item);

		public bool Delete(int id) => CommonDeleteAsync(id).Result;

		public bool Delete(ICustomer item) => CommonDeleteAsync(item).Result;

		public Task<bool> DeleteAsync(int id) => CommonDeleteAsync(id);

		public Task<bool> DeleteAsync(ICustomer item) => CommonDeleteAsync(item);
	}
}
