namespace Shard.Internal
{
	using System.Text;



	public static class BinaryFormat
	{
		public static readonly byte[] DeltaHeader = Encoding.ASCII.GetBytes("SHARD-DELTA");
		public const byte DeltaVersion = 0x01;
		public static readonly byte[] EndOfMetadata = Encoding.ASCII.GetBytes(">>>");

		public const byte CopyCommand = 0x60;
		public const byte DataCommand = 0x80;



		/// <summary>Compares two byte-arrays and returns true, if data is equal, otherwise, returns false.</summary>
		/// <param name="bytes0">Byte-array.</param>
		/// <param name="bytes1">Byte-array.</param>
		/// <returns>True if byte-arrays are equal, otherwise false.</returns>
		public static bool Equals(byte[] bytes0, byte[] bytes1)
		{
			// It's already mismatched, if length of arrays are not equal
			if (bytes0.Length != bytes1.Length) return false;

			// Comparing each byte to byte
			for (var n = 0; n < bytes0.Length; n++)
			{
				if (bytes0[n] != bytes1[n]) return false;
			}

			return true;
		}



	}



}