using ProjectODataServer.Json;
using Shouldly;
using System;
using Xunit;

namespace ProjectODataServer.Tests.Json
{
	public class MessagePackJsonSerializerTest
	{
		[Fact]
		public void SerializeObject_WhenParamaterIsNull_ThenReturnStringHasNullTextValue()
		{
			// Arrange
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			// Act
			var result = service.SerializeObject<string>(null);

			// Assert
			//Assert.Equal("null", result);
			result.ShouldBe("null");
		}

		[Fact]
		public void SerializeObject_WhenParamaterHasIntValue_ThenReturnStringHasAIntegerTextValue()
		{
			// Arrange
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			// Act
			var result = service.SerializeObject<int>(5);

			// Assert
			//Assert.Equal("5", result);
			result.ShouldNotBeNull();
			result.ShouldNotBeEmpty();
			result.ShouldBe("5");
			result.ShouldBeOfType<string>();
		}

		[Fact]
		public void SerializeObject_WhenParamaterIsInTestClassImplementation_ThenReturnStringHasAValue()
		{
			// Arrange
			var obj = new TestClass()
			{
				Id = 5,
				Name = "Deneme"
			};

			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			// Act
			var result = service.SerializeObject(obj);

			// Assert
			//Assert.Equal("{\"Id\":5,\"Name\":\"Deneme\"}", result);
			result.ShouldBe("{\"Id\":5,\"Name\":\"Deneme\"}");
		}

		[Fact]
		public void DeserializeObject_WhenParameterIsNull_ThenThrowException()
		{
			// Arrange
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			// Act
			var result = Should.Throw<ArgumentNullException>(() => service.DeserializeObject<string>(null));

			// Assert
			result.ShouldNotBeNull();
			result.ParamName.ShouldBe("json");
		}

		public class TestClass
		{
			public int Id { get; set; }

			public string Name { get; set; }
		}
	}
}