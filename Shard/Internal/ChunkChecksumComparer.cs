namespace Shard.Internal
{
	using System.Collections.Generic;



	/// <summary>Represents a sorting algorithm for <see cref="Shard.Interfaces.ISignature"/> <see cref="Shard.Internal.Chunk"/>.</summary>
	/// <seealso cref="System.Collections.Generic.IComparer{Shard.Internal.Chunk}" />
	public sealed class ChunkChecksumComparer : IComparer<Chunk>
	{



		public int Compare(Chunk x, Chunk y)
		{
			return x.RollingChecksum.CompareTo(y.RollingChecksum);
		}



	}



}