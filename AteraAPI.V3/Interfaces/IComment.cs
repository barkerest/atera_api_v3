using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for comments.
	/// </summary>
	public interface IComment : IApiModel
	{
		/// <summary>
		/// The date/time of the comment.
		/// </summary>
		DateTime Date { get; }
		
		/// <summary>
		/// The comment.
		/// </summary>
		string Message { get; }
		
		/// <summary>
		/// The end user who wrote the comment.
		/// </summary>
		int? EndUserID { get; }
		
		/// <summary>
		/// The technician who wrote the comment.
		/// </summary>
		int? TechnicianContactID { get; }
		
		/// <summary>
		/// The email address of the comment writer.
		/// </summary>
		string Email { get; }
		
		/// <summary>
		/// The first name of the comment writer.
		/// </summary>
		string FirstName { get; }
		
		/// <summary>
		/// The last name of the comment writer.
		/// </summary>
		string LastName { get; }
		
		/// <summary>
		/// Is this an internal comment.
		/// </summary>
		bool IsInternal { get; }
	}
}
