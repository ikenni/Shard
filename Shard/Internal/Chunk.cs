namespace Shard.Internal
{



	/// <summary>Represents a signle chunk of <see cref="Shard.Interfaces.ISignature"/></summary>
	public sealed class Chunk
	{
		public byte[] Hash;
		public short Length;
		public long Offset;
		public uint RollingChecksum;
	}



}