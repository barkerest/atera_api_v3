using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AteraAPI.V3.Models.Internal
{
	internal class Duration : IDuration
	{
		[JsonProperty("ticketId")] public int TicketID { get; set; }

		public double OffSLADurationHours { get; set; }

		public double OffSiteDurationHours { get; set; }

		public double OnSLADurationHours { get; set; }

		public double OnSiteDurationHours { get; set; }

		public double TotalDurationHours { get; set; }

		public override string ToString()
		{
			return $"{TotalDurationHours:0.00} hours";
		}

		private bool Equals(IDuration other)
		{
			return TicketID == other.TicketID && OffSLADurationHours.Equals(other.OffSLADurationHours) && OffSiteDurationHours.Equals(other.OffSiteDurationHours) &&
			       OnSLADurationHours.Equals(other.OnSLADurationHours) && OnSiteDurationHours.Equals(other.OnSiteDurationHours) && TotalDurationHours.Equals(other.TotalDurationHours);
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IDuration other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = TicketID;
				hashCode = (hashCode * 397) ^ OffSLADurationHours.GetHashCode();
				hashCode = (hashCode * 397) ^ OffSiteDurationHours.GetHashCode();
				hashCode = (hashCode * 397) ^ OnSLADurationHours.GetHashCode();
				hashCode = (hashCode * 397) ^ OnSiteDurationHours.GetHashCode();
				hashCode = (hashCode * 397) ^ TotalDurationHours.GetHashCode();
				return hashCode;
			}
		}
	}
}
