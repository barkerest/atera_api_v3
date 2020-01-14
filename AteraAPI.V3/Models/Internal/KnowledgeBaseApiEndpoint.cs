using System;
using System.Linq;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class KnowledgeBaseApiEndpoint : CommonApiEndpointBase<IKnowledgeBaseEntry, KnowledgeBaseEntry>, IKnowledgeBaseApiEndpoint
	{
		internal KnowledgeBaseApiEndpoint(ApiContext context) 
			: base(context, "knowledgebases", m => m.KBID)
		{
		}

		public override IKnowledgeBaseEntry Find(int id) => CommonGetEnumerable(_name).FirstOrDefault(x => x.KBID == id);

		public override async Task<IKnowledgeBaseEntry> FindAsync(int id) => (await CommonGetEnumerableAsync(_name)).FirstOrDefault(x => x.KBID == id);

	}
}
