using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectODataServer
{
	public class MessagePackJsonSerializer
	{
		public string SerializeObject<T>(T obj)
		{
			return MessagePackSerializer.SerializeToJson(obj, MessagePack.Resolvers.ContractlessStandardResolver.Options);
		}


		public T DeserializeObject<T>(string json)
		{
			var a = MessagePackSerializer.ConvertFromJson(json, MessagePack.Resolvers.ContractlessStandardResolver.Options);
			return MessagePackSerializer.Deserialize<T>(a, MessagePack.Resolvers.ContractlessStandardResolver.Options);
		}
	}
}
