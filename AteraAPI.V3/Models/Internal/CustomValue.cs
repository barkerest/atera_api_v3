using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class CustomValue : ICustomValue
	{
		public int       ItemId          { get; set; }
		public string    Id              { get; set; }
		public string    FieldName       { get; set; }
		public string    ValueAsString   { get; set; }
		public double?   ValueAsDecimal  { get; set; }
		public DateTime? ValueAsDateTime { get; set; }
		public bool?     ValueAsBool     { get; set; }

		public override string ToString()
		{
			return $"{FieldName}: {ValueAsString}";
		}

		private bool Equals(ICustomValue other)
		{
			return ItemId == other.ItemId && Id == other.Id && FieldName == other.FieldName && ValueAsString == other.ValueAsString && Nullable.Equals(ValueAsDecimal, other.ValueAsDecimal) &&
			       Nullable.Equals(ValueAsDateTime, other.ValueAsDateTime) && ValueAsBool == other.ValueAsBool;
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is ICustomValue other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = ItemId;
				hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (FieldName != null ? FieldName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ValueAsString != null ? ValueAsString.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ ValueAsDecimal.GetHashCode();
				hashCode = (hashCode * 397) ^ ValueAsDateTime.GetHashCode();
				hashCode = (hashCode * 397) ^ ValueAsBool.GetHashCode();
				return hashCode;
			}
		}
	}
}
