using System;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class RateApiEndpoint : CommonApiEndpointBase<IRate, Rate>, IRateApiEndpoint
	{
		internal RateApiEndpoint(ApiContext context, string rateType) 
			: base(context, $"rates/{rateType}", m => m.RateID)
		{
		}

		public int Create(IRate item) => CommonCreateAsync(item).Result;

		public Task<int> CreateAsync(IRate item) => CommonCreateAsync(item);

		public bool Update(int id, IRate item) => CommonUpdateAsync(id, item).Result;

		public bool Update(IRate item) => CommonUpdateAsync(item).Result;

		public Task<bool> UpdateAsync(int id, IRate item) => CommonUpdateAsync(id, item);

		public Task<bool> UpdateAsync(IRate item) => CommonUpdateAsync(item);

		public bool Delete(int id) => CommonDeleteAsync(id).Result;

		public bool Delete(IRate item) => CommonDeleteAsync(item).Result;

		public Task<bool> DeleteAsync(int id) => CommonDeleteAsync(id);

		public Task<bool> DeleteAsync(IRate item) => CommonDeleteAsync(item);
	}
}
