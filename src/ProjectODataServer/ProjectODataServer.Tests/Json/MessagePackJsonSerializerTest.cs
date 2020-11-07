using ProjectODataServer.Json;
using Xunit;

namespace ProjectODataServer.Tests.Json
{
	public class MessagePackJsonSerializerTest
	{
		[Fact]
		public void SerializeObject_WhenParamaterIsNull_ThenReturnStringHasNullTextValue()
		{
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			var result = service.SerializeObject<string>(null);

			Assert.Equal("null", result);
		}

		[Fact]
		public void SerializeObject_WhenParamaterHasIntValue_ThenReturnStringHasAIntegerTextValue()
		{
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			var result = service.SerializeObject<int>(5);

			Assert.Equal("5", result);
		}


		[Fact]
		public void SerializeObject_WhenParamaterIsInTestClassImplementation_ThenReturnStringHasAValue()
		{
			var obj = new TestClass()
			{
				Id = 5,
				Name = "Deneme"
			};

			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			var result = service.SerializeObject(obj);

			Assert.Equal("{\"id\":5,\"name\":\"Deneme\"}", result);
		}

		public class TestClass
		{
			public int Id { get; set; }

			public string Name { get; set; }
		}
	}
}