using System;
using AteraAPI.V3.Interfaces;

namespace AteraAPI.V3.Models.Internal
{
	internal class CustomValue : ICustomValue
	{
		public int ItemId { get; set; }
		public string Id { get; set; }
		public string FieldName { get; set; }
		public string ValueAsString { get; set; }
		public double? ValueAsDecimal { get; set; }
		public DateTime? ValueAsDateTime { get; set; }
		public bool? ValueAsBool { get; set; }
	}
}
