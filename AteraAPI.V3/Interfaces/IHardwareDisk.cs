namespace AteraAPI.V3.Interfaces
{
	public interface IHardwareDisk : IApiModel
	{
		/// <summary>
		/// The drive letter.
		/// </summary>
		string Drive { get; }
		
		/// <summary>
		/// MB free
		/// </summary>
		long? Free { get; }
		
		/// <summary>
		/// MB used
		/// </summary>
		long? Used { get; }
		
		/// <summary>
		/// Size of disk in MB
		/// </summary>
		long? Total { get; }
	}
}
