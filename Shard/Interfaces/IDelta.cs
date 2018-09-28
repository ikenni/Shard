namespace Shard.Interfaces
{
	


	/// <summary>Basic interface for classes, that implements Delta-mechanism.</summary>
	public interface IDelta
	{
		IProgressReporter ProgressReporter { get; set; }

		long Identifier { get; set; }
		long Database { get; set; }
	}



}
