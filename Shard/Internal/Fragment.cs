namespace Shard.Internal
{



	/// <summary>Represents an instruction, used by <see cref="Shard.Interfaces.IDelta"/>, that contains information about offset and length of data, that must be copied.</summary>
	public sealed class Fragment
	{
		public readonly long Offset;
		public readonly long Length;



		public Fragment(long offset, long length)
		{
			Offset = offset;
			Length = length;
		}



	}



}
