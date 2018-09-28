namespace Shard.Internal
{
	using System;
	using System.Runtime.Serialization;
	using System.Security.Permissions;



	[Serializable]
	public sealed class VersionNotSupportedException : Exception
	{
		public byte Version { get; }
		public byte SupportedVersion { get; }



		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public VersionNotSupportedException(byte version, byte supportedVersion)
		{
			Version = version;
			SupportedVersion = supportedVersion;
		}



		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Version", Version);
			info.AddValue("SupportedVersion", SupportedVersion);
			base.GetObjectData(info, context);
		}



	}



}