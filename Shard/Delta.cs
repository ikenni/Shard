namespace Shard
{
	using System.IO;
	
	using Shard.Interfaces;
	using Shard.Internal;



	public class Delta : IDelta
	{
		public static readonly int ReadBufferSize = 4194304;

		public IProgressReporter ProgressReporter { get; set; }
		public long Identifier { get; set; }
		public long Database { get; set; }



		public void Compute(Stream source, Stream destination, Stream output)
		{
		}



		public void Apply(Stream basis, Stream delta, Stream output)
		{
		}



		private static void ReadDataCommand(BinaryReader reader, Stream output)
		{
		}



		private static void ReadCopyCommand(Stream basis, Stream output, long offset, long length)
		{
		}



		private static void WriteDataCommand(BinaryWriter delta, Stream source, long offset, long length)
		{
		}



		private static void WriteCopyCommand(BinaryWriter delta, Fragment segment)
		{
		}



	}



}
