using System;
using System.Threading.Tasks;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class ProjectOneTimeFeeContract : IContractOneTimeFeeDetails
	{
		[JsonConverter(typeof(ConcreteConverter<Rate>))]
		public IRate TotalAmount { get; set; }

		public override string ToString()
		{
			return $"One Time Fee: {TotalAmount}";
		}

		private bool Equals(IContractOneTimeFeeDetails other)
		{
			return Equals(TotalAmount, other.TotalAmount);
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IContractOneTimeFeeDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			return (TotalAmount != null ? TotalAmount.GetHashCode() : 0);
		}
	}
}
