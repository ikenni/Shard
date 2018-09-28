namespace Shard.Internal
{
	using System;
	using System.IO;
	using System.Collections.Generic;

	using Interfaces;



	/// <summary>Represents a standard <see cref="ISignature"/>, that generates <see cref="Chunk"/>-map from <see cref="Stream"/>, which is helpful while determining difference between two <see cref="Stream"/> objects.</summary>
	/// <seealso cref="Shard.Interfaces.ISignature" />
	public sealed class Signature : ISignature
	{
		public IHashAlgorithm HashAlgorithm { get; set; }
		public IRollingChecksum RollingChecksumAlgorithm { get; set; }

		public List<Chunk> Chunks { get; private set; }



		public Signature(Stream stream, IProgressReporter progressReporter)
		{
			Chunks = new List<Chunk>();

			// Creating instances of algorithms from repository
			if (HashAlgorithm == null) HashAlgorithm = SupportedAlgorithms.Hash();
			if (RollingChecksumAlgorithm == null) RollingChecksumAlgorithm = SupportedAlgorithms.Checksum();

			// Reseting position of stream
			stream.Seek(0, SeekOrigin.Begin);

			// ...
			var chunkSize = ComputeChunkSize(stream.Length);
			long offset = 0;
			int length;
			var buffer = new byte[chunkSize];

			// Generating hash and checksum for each chunk of signature
			while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
			{
				Chunks.Add(new Chunk() {
					Offset = offset,
					Length = (short)length,
					Hash = HashAlgorithm.ComputeHash(buffer, 0, length),
					RollingChecksum = RollingChecksumAlgorithm.Calculate(buffer, 0, length)
				});

				// ...
				offset += length;

				// Checking for cancellation and reporting about progress
				if (progressReporter == null) continue;
				if (progressReporter.CancellationPending) return;
				progressReporter.OnProgressChanged(ProgressOperation.ComputingSignature, offset, stream.Length);
			}
		}



		private static int ComputeChunkSize(long streamLength)
		{
			var size = (int)Math.Sqrt(streamLength);
			
			// Not less than 128 and not larger than 31744
			return size < 128 ? 128 : (size > 31744 ? 31744 : size);
		}



		public Dictionary<uint, int> GetChunkMap(out int min, out int max)
		{
			max = 0;
			min = int.MaxValue;

			var chunkMap = new Dictionary<uint, int>();

			for (var i = 0; i < Chunks.Count; i++)
			{
				if (Chunks[i].Length > max) max = Chunks[i].Length;
				if (Chunks[i].Length < min) min = Chunks[i].Length;
				if (!chunkMap.ContainsKey(Chunks[i].RollingChecksum))
				{
					chunkMap[Chunks[i].RollingChecksum] = i;
				}
			}

			return chunkMap;
		}



		public void Dispose()
		{
			HashAlgorithm.Dispose();
		}



	}



}