namespace Shard.Internal
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Security.Cryptography;

	using Shard.Interfaces;



	/// <summary>Represents a wrapper for objects, that derived from <see cref="System.Security.Cryptography.HashAlgorithm"/>.</summary>
	/// <seealso cref="Shard.Interfaces.IHashAlgorithm" />
	/// <seealso cref="HashAlgorithm" />
	public sealed class HashingAlgorithm : IHashAlgorithm
	{
		public HashAlgorithm Algorithm;

		public string Name { get; }
		public int HashLength { get { return Algorithm.HashSize / 8; } }

		private bool _isDisposed;



		public HashingAlgorithm(string name, HashAlgorithm algorithm)
		{
			Name = name;
			Algorithm = algorithm;
		}



		public byte[] ComputeHash(Stream stream)
		{
			// Throwing exception, if hash algorithm was disposed
			if (_isDisposed) throw new ObjectDisposedException(nameof(Algorithm));

			// Reseting position and computing hash
			stream.Seek(0, SeekOrigin.Begin);
			return Algorithm.ComputeHash(stream);
		}



		public byte[] ComputeHash(Stream stream, IProgressReporter progressReporter, ProgressOperation operation)
		{
			// Throwing exception, if hash algorithm was disposed
			if (_isDisposed) throw new ObjectDisposedException(nameof(Algorithm));

			// Shortcut, if length of stream is less than size of one package
			if (stream.Length <= 4096)
			{
				Debug.WriteLine("Stream.Length is less than 4096 bytes, computing of hash will be performed through standart method ComputeHash(Stream)");
				return ComputeHash(stream);
			}

			// ...
			stream.Seek(0, SeekOrigin.Begin);
			progressReporter?.OnProgressChanged(operation, stream.Position, stream.Length);

			// ...
			var interval = 0;
			var buffer = new byte[4096];

			// ...
			while (true)
			{
				var length = stream.Read(buffer, 0, buffer.Length);
				if (length < buffer.Length || stream.Position == stream.Length)
				{
					// End of stream, performing TransformFinalBlock
					Algorithm.TransformFinalBlock(buffer, 0, length);
					progressReporter?.OnProgressChanged(operation, stream.Length, stream.Length);
					return Algorithm.Hash;
				}
				else
				{
					// Regular block transform
					Algorithm.TransformBlock(buffer, 0, buffer.Length, null, 0);
				}

				// If IProgressReporter has been specified
				if (progressReporter == null) continue;

				// Cancelling operation, if requested
				if (progressReporter.CancellationPending) return null;

				// Reporting about progress each 250 kylobytes
				if (++interval > 60)
				{
					interval = 0;
					progressReporter.OnProgressChanged(operation, stream.Position, stream.Length);
				}
			}
		}



		public byte[] ComputeHash(byte[] buffer, int offset, int length)
		{
			// Throwing exception, if hash algorithm was disposed
			if (_isDisposed) throw new ObjectDisposedException(nameof(Algorithm));
			return Algorithm.ComputeHash(buffer, offset, length);
		}



		public void Dispose()
		{
			if (_isDisposed) return;
			_isDisposed = true;

			Algorithm.Clear();
		}



	}



}