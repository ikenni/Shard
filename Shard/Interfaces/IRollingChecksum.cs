namespace Shard.Interfaces
{
	using System;



	/// <summary>Interface for universal rolling checksum algorithm class, that contains all necessary methods and properties for proper work of <see cref="IDelta"/>, <see cref="ISignature"/> and etc.</summary>
	/// <seealso cref="IDisposable" />
	public interface IRollingChecksum : IDisposable
	{
		string Name { get; }

		uint Calculate(byte[] block, int offset, int count);
		uint Rotate(uint checksum, byte remove, byte add, int chunkSize);
	}



}