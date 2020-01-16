using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for custom values.
	/// </summary>
	public interface ICustomValue : IApiModel
	{
		/// <summary>
		/// The numeric ID.
		/// </summary>
		int ItemId { get; }
		
		/// <summary>
		/// The GUID.
		/// </summary>
		string Id { get; }
		
		/// <summary>
		/// The field name.
		/// </summary>
		string FieldName { get; }
		
		/// <summary>
		/// The value as a string.
		/// </summary>
		string ValueAsString { get; }
		
		/// <summary>
		/// The value as a number.
		/// </summary>
		double? ValueAsDecimal { get; }
		
		/// <summary>
		/// The value as a date/time.
		/// </summary>
		DateTime? ValueAsDateTime { get; }
		
		/// <summary>
		/// The value as a boolean.
		/// </summary>
		bool? ValueAsBool { get; }
	}
}
