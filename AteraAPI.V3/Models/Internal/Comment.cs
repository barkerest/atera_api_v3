using System;
using AteraAPI.V3.Interfaces;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class Comment : IComment
	{
		public DateTime Date { get; set; }

		[JsonProperty("Comment")] public string Message { get; set; }

		public int?   EndUserID           { get; set; }
		public int?   TechnicianContactID { get; set; }
		public string Email               { get; set; }
		public string FirstName           { get; set; }
		public string LastName            { get; set; }
		public bool   IsInternal          { get; set; }

		public override string ToString()
		{
			var dir = EndUserID.HasValue
				          ? ">"
				          : TechnicianContactID.HasValue
					          ? "<"
					          : "-";

			var msg                  = Message ?? "";
			if (msg.Length > 49) msg = msg.Substring(0, 47) + "...";

			return $"({dir}) {msg}";
		}


		private bool Equals(IComment other)
		{
			return Date.Equals(other.Date) && Message == other.Message && EndUserID == other.EndUserID && TechnicianContactID == other.TechnicianContactID && Email == other.Email &&
			       FirstName == other.FirstName && LastName == other.LastName && IsInternal == other.IsInternal;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is IComment other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Date.GetHashCode();
				hashCode = (hashCode * 397) ^ (Message != null ? Message.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ EndUserID.GetHashCode();
				hashCode = (hashCode * 397) ^ TechnicianContactID.GetHashCode();
				hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ IsInternal.GetHashCode();
				return hashCode;
			}
		}
	}
}
