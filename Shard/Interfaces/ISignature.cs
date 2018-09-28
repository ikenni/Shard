namespace Shard.Interfaces
{
	using System;
	using System.Collections.Generic;

	using Shard.Internal;



	/// <summary>Basic interface for classes, that implements Signature-mechanism. Interface required by <see cref="IDelta"/> in order to transparently interact with signature from IDelta-class.</summary>
	/// <seealso cref="IDisposable" />
	public interface ISignature : IDisposable
	{
		IHashAlgorithm HashAlgorithm { get; set; }
		IRollingChecksum RollingChecksumAlgorithm { get; set; }
		List<Chunk> Chunks { get; }

		Dictionary<uint, int> GetChunkMap(out int min, out int max);
	}



}