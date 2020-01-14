using System;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class ContactApiEndpoint : CommonApiEndpointBase<IContact,Contact>, IContactApiEndpoint
	{
		internal ContactApiEndpoint(ApiContext context) 
			: base(context, "contacts", m => m.ContactID)
		{
		}

		public int Create(IContact item) => CommonCreateAsync(item).Result;

		public Task<int> CreateAsync(IContact item) => CommonCreateAsync(item);

		public bool Update(int id, IContact item) => CommonUpdateAsync(id, item).Result;

		public bool Update(IContact item) => CommonUpdateAsync(item).Result;

		public Task<bool> UpdateAsync(int id, IContact item) => CommonUpdateAsync(id, item);

		public Task<bool> UpdateAsync(IContact item) => CommonUpdateAsync(item);

		public bool Delete(int id) => CommonDeleteAsync(id).Result;

		public bool Delete(IContact item) => CommonDeleteAsync(item).Result;

		public Task<bool> DeleteAsync(int id) => CommonDeleteAsync(id);

		public Task<bool> DeleteAsync(IContact item) => CommonDeleteAsync(item);
	}
}
