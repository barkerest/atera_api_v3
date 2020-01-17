using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class HardwareDisk : IHardwareDisk
	{
		public string Drive { get; set; }
		public long? Free { get; set; }
		public long? Used { get; set; }
		public long? Total { get; set; }

		public override string ToString()
		{
			return Drive;
		}

		private bool Equals(IHardwareDisk other)
		{
			return Drive == other.Drive && Free == other.Free && Used == other.Used && Total == other.Total;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IHardwareDisk other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Drive != null ? Drive.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Free.GetHashCode();
				hashCode = (hashCode * 397) ^ Used.GetHashCode();
				hashCode = (hashCode * 397) ^ Total.GetHashCode();
				return hashCode;
			}
		}
	}
}
