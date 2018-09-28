namespace Shard.Internal
{
	using System.Security.Cryptography;
	using Interfaces;



	/// <summary>Repository, that contains all hash and rolling checksum algorithms, that supported in current version of <see cref="Shard"/>.</summary>
	public static class SupportedAlgorithms
	{
		public const string DefaultHash = "SHA1MANAGED";
		public const string DefaultChecksum = "ADLER32";



		public static IHashAlgorithm Hash(string name = null)
		{
			// Choosing default algorithm, if not specified
			if (name == null) name = DefaultHash;

			// Depending on name, creating instance of specific algorithm
			switch (name)
			{
				case "SHA1": return new HashingAlgorithm(name, SHA1.Create());
				case "SHA256": return new HashingAlgorithm(name, SHA256.Create());
				case "SHA384": return new HashingAlgorithm(name, SHA384.Create());
				case "SHA512": return new HashingAlgorithm(name, SHA512.Create());
				case "SHA1MANAGED": return new HashingAlgorithm(name, new SHA1Managed());
				case "SHA256MANAGED": return new HashingAlgorithm(name, new SHA256Managed());
				case "SHA384MANAGED": return new HashingAlgorithm(name, new SHA384Managed());
				case "SHA512MANAGED": return new HashingAlgorithm(name, new SHA512Managed());
				default: return null;
			}
		}



		public static IRollingChecksum Checksum(string name = null)
		{
			// Choosing default algorithm, if not specified
			if (name == null) name = DefaultChecksum;

			// Depending on name, creating instance of specific algorithm
			switch (name)
			{
				case "ADLER32": return new Adler32RollingChecksum();
				default: return null;
			}
		}



	}



}