using MessagePack;
using System.Threading.Tasks;

namespace ProjectODataServer.Json
{
	public class MessagePackJsonSerializer : IJsonSerializer
	{
		public string SerializeObject<T>(T obj)
		{
			return MessagePackSerializer.SerializeToJson(obj, MessagePack.Resolvers.ContractlessStandardResolver.Options);
		}

		public Task<string> SerializeObjectAsync<T>(T obj)
		{
			return Task.Run(() => MessagePackSerializer.SerializeToJson(obj, MessagePack.Resolvers.ContractlessStandardResolver.Options));
		}

		public T DeserializeObject<T>(string json)
		{
			var a = MessagePackSerializer.ConvertFromJson(json, MessagePack.Resolvers.ContractlessStandardResolver.Options);
			return MessagePackSerializer.Deserialize<T>(a, MessagePack.Resolvers.ContractlessStandardResolver.Options);
		}

		public Task<T> DeserializeObjectAsync<T>(string json)
		{
			return Task.Run(() => DeserializeObject<T>(json));
		}
	}
}