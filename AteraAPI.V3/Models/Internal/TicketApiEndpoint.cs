using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class TicketApiEndpoint : CommonApiEndpointBase<ITicket, Ticket>, ITicketApiEndpoint
	{
		internal TicketApiEndpoint(ApiContext context) 
			: base(context, "tickets", m => m.TicketID)
		{
		}

		public int Create(ITicket item) => CommonCreateAsync(item).Result;

		public Task<int> CreateAsync(ITicket item) => CommonCreateAsync(item);
		
		public ITicket Create(Action<ITicket> init) => CreateAsync(init).Result;
		
		public async Task<ITicket> CreateAsync(Action<ITicket> init)
		{
			if (init is null) throw new ArgumentNullException(nameof(init));
			var item = new Ticket();
			init(item);
			item.TicketID = await CreateAsync(item);
			return item;
		}

		public ITicket NewItem() => new Ticket();

		public bool Update(int id, ITicket item) => CommonUpdateAsync(id, item).Result;

		public bool Update(ITicket item) => CommonUpdateAsync(item).Result;

		public Task<bool> UpdateAsync(int id, ITicket item) => CommonUpdateAsync(id, item);

		public Task<bool> UpdateAsync(ITicket item) => CommonUpdateAsync(item);

		public bool Delete(int id) => CommonDeleteAsync(id).Result;

		public bool Delete(ITicket item) => CommonDeleteAsync(item).Result;

		public Task<bool> DeleteAsync(int id) => CommonDeleteAsync(id);

		public Task<bool> DeleteAsync(ITicket item) => CommonDeleteAsync(item);

		public IEnumerable<ITicket> GetResolvedAndClosed() => CommonGetEnumerable($"{_name}/statusmodified");

		public Task<IEnumerable<ITicket>> GetResolvedAndClosedAsync() => CommonGetEnumerableAsync($"{_name}/statusmodified");

		public async Task<IDuration> GetBillableDurationAsync(int ticketId) => await _context.ExecuteAsync<Duration>($"{_name}/{ticketId}/billableduration");
		
		public async Task<IDuration> GetNonBillableDurationAsync(int ticketId)=> await _context.ExecuteAsync<Duration>($"{_name}/{ticketId}/nonbillableduration");

		public async Task<IWorkHours> GetWorkHoursAsync(int ticketId) => await _context.ExecuteAsync<WorkHours>($"{_name}/{ticketId}/workhours");

		public Task<IEnumerable<IWorkHourRecord>> GetWorkHourRecordsAsync(int ticketId) => CommonGetEnumerableAsync<IWorkHourRecord, WorkHourRecord>($"{_name}/{ticketId}/workhoursrecords");

		public Task<IEnumerable<IComment>> GetCommentsAsync(int ticketId) => CommonGetEnumerableAsync<IComment, Comment>($"{_name}/{ticketId}/comments");

		public IDuration GetBillableDuration(int ticketId) => GetBillableDurationAsync(ticketId).Result;

		public IDuration GetNonBillableDuration(int ticketId) => GetNonBillableDurationAsync(ticketId).Result;

		public IWorkHours GetWorkHours(int ticketId) => GetWorkHoursAsync(ticketId).Result;

		public IEnumerable<IWorkHourRecord> GetWorkHourRecords(int ticketId) => CommonGetEnumerable<IWorkHourRecord, WorkHourRecord>($"{_name}/{ticketId}/workhoursrecords");
		
		public IEnumerable<IComment> GetComments(int ticketId) => CommonGetEnumerable<IComment, Comment>($"{_name}/{ticketId}/comments");
	}
}
