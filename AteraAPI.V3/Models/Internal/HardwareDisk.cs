using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class HardwareDisk : IHardwareDisk
	{
		public string Drive { get; set; }
		public long? Free { get; set; }
		public long? Used { get; set; }
		public long? Total { get; set; }
	}
}
