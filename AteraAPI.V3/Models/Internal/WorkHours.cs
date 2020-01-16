using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class WorkHours : IWorkHours
	{
		public int TicketID { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<Duration>))]
		public IDuration Billable { get; set; }
		
		[JsonConverter(typeof(ConcreteConverter<Duration>))]
		public IDuration NonBillable { get; set; }

		public override string ToString()
		{
			return $"Billable: {Billable}, Non-billable: {NonBillable}";
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is IWorkHours other)) return false;
			return Equals(other);
		}

		private bool Equals(IWorkHours other)
		{
			return TicketID == other.TicketID && Equals(Billable, other.Billable) && Equals(NonBillable, other.NonBillable);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = TicketID;
				hashCode = (hashCode * 397) ^ (Billable != null ? Billable.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (NonBillable != null ? NonBillable.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
