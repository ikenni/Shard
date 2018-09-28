namespace Shard.Internal
{
	using System;
	using System.Runtime.Serialization;
	using System.Security.Permissions;



	[Serializable]
	public sealed class AlgorithmNotSupportedException : Exception
	{
		public string Name { get; }



		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public AlgorithmNotSupportedException(string name)
		{
			Name = name;
		}



		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			base.GetObjectData(info, context);
		}



	}



}
