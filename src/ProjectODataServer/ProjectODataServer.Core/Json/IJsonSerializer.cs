using System.Threading.Tasks;

namespace ProjectODataServer.Json
{
	public interface IJsonSerializer
	{
		T DeserializeObject<T>(string json);
		Task<T> DeserializeObjectAsync<T>(string json);
		string SerializeObject<T>(T obj);
		Task<string> SerializeObjectAsync<T>(T obj);
	}
}