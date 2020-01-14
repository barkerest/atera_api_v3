using System.Threading.Tasks;
using AteraAPI.V3.Enums;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the API endpoint for custom values.
	/// </summary>
	public interface ICustomValueApiEndpoint
	{
		/// <summary>
		/// Find a custom value by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		ICustomValue Find(string id);

		/// <summary>
		/// Find a custom value by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ICustomValue> FindAsync(string id);

		/// <summary>
		/// Find a custom value for a specific target item.
		/// </summary>
		/// <param name="targetType">The type of target item.</param>
		/// <param name="targetId">The ID for the target item.</param>
		/// <param name="fieldName">The name of the field to retrieve.</param>
		/// <returns></returns>
		ICustomValue FindFor(CustomFieldTarget targetType, int targetId, string fieldName);
		
		/// <summary>
		/// Find a custom value for a specific target item.
		/// </summary>
		/// <param name="targetType">The type of target item.</param>
		/// <param name="targetId">The ID for the target item.</param>
		/// <param name="fieldName">The name of the field to retrieve.</param>
		/// <returns></returns>
		Task<ICustomValue> FindForAsync(CustomFieldTarget targetType, int targetId, string fieldName);
	}
}
