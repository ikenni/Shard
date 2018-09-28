namespace Shard.Interfaces
{



	/// <summary>Interfaces, that connects Shard classes with background worker, that needs information about progress, and, might require cancellation.</summary>
	public interface IProgressReporter
	{
		bool CancellationPending { get; }

		void OnProgressChanged(ProgressOperation operation, long offset, long length);
	}



}