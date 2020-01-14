using System;

namespace AteraAPI.V3.Interfaces
{
	/// <summary>
	/// Defines the interface for knowledge base entries.
	/// </summary>
	public interface IKnowledgeBaseEntry
	{
		/// <summary>
		/// The ID of the entry.
		/// </summary>
		int KBID { get; }
		
		/// <summary>
		/// The timestamp of the entry.
		/// </summary>
		DateTime Timestamp { get; }
		
		/// <summary>
		/// The context of the entry.
		/// </summary>
		string Context { get; }
		
		/// <summary>
		/// The product for the entry.
		/// </summary>
		string Product { get; }
		
		/// <summary>
		/// Yes ratings.
		/// </summary>
		int Rating_Yes { get; }
		
		/// <summary>
		/// No ratings.
		/// </summary>
		int Rating_No { get; }
		
		/// <summary>
		/// Views.
		/// </summary>
		int Rating_Views { get; }
		
		/// <summary>
		/// Date/time the entry was last modified.
		/// </summary>
		DateTime LastModified { get; }
		
		/// <summary>
		/// Is this a private entry.
		/// </summary>
		bool IsPrivate { get; }
		
		/// <summary>
		/// Status of the entry.
		/// </summary>
		int Status { get; }
		
		/// <summary>
		/// The priority of the entry.
		/// </summary>
		int Priority { get; }
		
		/// <summary>
		/// Keywords for the entry.
		/// </summary>
		string Keywords { get; }
		
		/// <summary>
		/// The address for the entry.
		/// </summary>
		string Address { get; }
	}
}
