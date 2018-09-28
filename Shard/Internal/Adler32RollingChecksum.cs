namespace Shard.Internal
{
	using System;

	using Shard.Interfaces;



	internal sealed class Adler32RollingChecksum : IRollingChecksum
	{
		public string Name => "ADLER32";



		public uint Calculate(byte[] block, int offset, int count)
		{
			var a = 1;
			var b = 0;

			for (var i = offset; i < offset + count; i++)
			{
				var z = block[i];
				a = (ushort)(z + a);
				b = (ushort)(b + a);
			}

			return (uint)((b << 16) | a);
		}



		public uint Rotate(uint checksum, byte remove, byte add, int chunkSize)
		{
			var b = (ushort)(checksum >> 16 & 0xffff);
			var a = (ushort)(checksum & 0xffff);

			a = (ushort)(a - remove + add);
			b = (ushort)(b - chunkSize * remove + a - 1);

			return (uint)((b << 16) | a);
		}



		public void Dispose()
		{
			throw new NotImplementedException();
		}



	}



}