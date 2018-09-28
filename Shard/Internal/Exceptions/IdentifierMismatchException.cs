namespace Shard.Internal
{
	using System;
	using System.Runtime.Serialization;
	using System.Security.Permissions;



	[Serializable]
	public sealed class IdentifierMismatchException : Exception
	{
		public long Database { get; }
		public long Delta { get; }



		public IdentifierMismatchException(long database, long delta)
		{
			Database = database;
			Delta = delta;
		}



		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Database", Database);
			info.AddValue("Delta", Delta);
			base.GetObjectData(info, context);
		}



	}



}
