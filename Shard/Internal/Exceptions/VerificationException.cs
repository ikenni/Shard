namespace Shard.Internal
{
	using System;
	using System.Runtime.Serialization;
	using System.Security.Permissions;



	[Serializable]
	public sealed class VerificationException : Exception, ISerializable
	{
		public byte[] ExpectedHash { get; }
		public byte[] ResultHash { get; }



		public VerificationException(byte[] expectedHash, byte[] resultHash)
		{
			ExpectedHash = expectedHash;
			ResultHash = resultHash;
		}



		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("ExpectedHash", ExpectedHash);
			info.AddValue("ResultHash", ResultHash);
			base.GetObjectData(info, context);
		}



	}



}
