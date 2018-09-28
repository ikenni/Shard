namespace Shard.Interfaces
{
	using System;
	using System.IO;



	/// <summary>Interface for universal hash algorithm class, that contains all necessary methods and properties for proper work of <see cref="IDelta"/>, <see cref="ISignature"/> and etc.</summary>
	/// <seealso cref="IDisposable" />
	public interface IHashAlgorithm : IDisposable
	{
		string Name { get; }
		int HashLength { get; }

		byte[] ComputeHash(Stream stream);
		byte[] ComputeHash(Stream stream, IProgressReporter progressReporter, ProgressOperation operation);
		byte[] ComputeHash(byte[] buffer, int offset, int length);
	}



}