using System;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class AlertApiEndpoint : CommonApiEndpointBase<IAlert, Alert>, IAlertApiEndpoint
	{
		internal AlertApiEndpoint(ApiContext context) 
			: base(context, "alerts", m => m.AlertID)
		{
		}

		public int Create(IAlert item) => CommonCreateAsync(item).Result;

		public Task<int> CreateAsync(IAlert item) => CommonCreateAsync(item);

		public IAlert Create(Action<IAlert> init) => CreateAsync(init).Result;

		public async Task<IAlert> CreateAsync(Action<IAlert> init)
		{
			if (init is null) throw new ArgumentNullException(nameof(init));
			var item = new Alert();
			init(item);
			item.AlertID = await CreateAsync(item);
			return item;
		}

		public IAlert NewItem() => new Alert();

		public bool Delete(int id) => CommonDeleteAsync(id).Result;

		public bool Delete(IAlert item) => CommonDeleteAsync(item).Result;

		public Task<bool> DeleteAsync(int id) => CommonDeleteAsync(id);

		public Task<bool> DeleteAsync(IAlert item) => CommonDeleteAsync(item);

	}
}
