using System;

namespace AteraAPI.V3.Exceptions
{
	/// <summary>
	/// The exception raised when a potential concurrency error occurs.
	/// </summary>
	public class ApiConcurrencyException : ApiException
	{
		/// <summary>
		/// Creates a new concurrency exception.
		/// </summary>
		/// <param name="message"></param>
		public ApiConcurrencyException(string message) : base(message)
		{
			
		}

		/// <summary>
		/// Creates a new concurrency exception.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public ApiConcurrencyException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
	}
}
