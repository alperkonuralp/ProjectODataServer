using MessagePack;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ProjectODataServer.InterfaceTests
{
	public static class TestHelperService
	{
		public static Dictionary<object, object> GetJsonDictionary(string jsonString)
		{
			var ms = new MemoryStream(MessagePackSerializer.ConvertFromJson(jsonString));

			var resultDictionary = MessagePackSerializer.Typeless.Deserialize(ms, MessagePackSerializerOptions.Standard) as Dictionary<object, object>;

			return resultDictionary;
		}

		public static string GetJsonString(Dictionary<object, object> jsonDictionary)
		{
			var resultBytes = MessagePackSerializer.Typeless.Serialize(jsonDictionary, MessagePackSerializerOptions.Standard);

			return MessagePackSerializer.ConvertToJson(resultBytes);
		}

		public static bool GetAndCompareResultFromWebRequestAndStoredData(
			string address,
			string expectedResultFileName,
			Action<Dictionary<object, object>> beforeOperation = null
			)
		{
			using var webClient = new WebClient();

			var result = webClient.DownloadString(address);

			var resultDictionary = GetJsonDictionary(result);
			beforeOperation?.Invoke(resultDictionary);

			result = GetJsonString(resultDictionary);

			if (!File.Exists(expectedResultFileName))
			{
				File.WriteAllText(expectedResultFileName, result);
			}
			else
			{
				var expectedResult = File.ReadAllText(expectedResultFileName);

				result.ShouldBe(expectedResult);
			}
			return true;
		}

		public static bool GetAndCompareStringResultFromWebRequestAndStoredData(
			string address,
			string expectedResultFileName
			)
		{
			using var webClient = new WebClient();

			var result = webClient.DownloadString(address);

			if (!File.Exists(expectedResultFileName))
			{
				File.WriteAllText(expectedResultFileName, result);
			}
			else
			{
				var expectedResult = File.ReadAllText(expectedResultFileName);

				result.ShouldBe(expectedResult);
			}
			return true;
		}

		public static string GetAndCompareResultFromWebRequest(string address, string expectedResult)
		{
			using var webClient = new WebClient();

			var result = webClient.DownloadString(address);

			result.ShouldNotBeEmpty();
			result.ShouldBe(expectedResult);

			return result;
		}
	}
}