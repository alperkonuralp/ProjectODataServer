using ProjectODataServer.Json;
using Shouldly;
using System;
using Xunit;

namespace ProjectODataServer.Tests.Json
{
	public class MessagePackJsonSerializerTest
	{
		[Theory]
		[InlineData(null, "null")]
		[InlineData("", "\"\"")]
		[InlineData("abc", "\"abc\"")]
		public void SerializeObject_WhenParamaterHasValue_ThenReturnStringHasNullTextValue(string request, string expected)
		{
			// Arrange
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			// Act
			var result = service.SerializeObject<string>(request);

			// Assert
			//Assert.Equal("null", result);
			result.ShouldNotBeNull();
			result.ShouldBe(expected);
		}

		[Theory]
		[InlineData(5, "5")]
		[InlineData(0, "0")]
		[InlineData(100, "100")]
		public void SerializeObject_WhenParamaterHasIntValue_ThenReturnStringHasAIntegerTextValue(int request, string expected)
		{
			// Arrange
			MessagePackJsonSerializer service = new MessagePackJsonSerializer();

			// Act
			var result = service.SerializeObject<int>(request);

			// Assert
			//Assert.Equal("5", result);
			result.ShouldNotBeNull();
			result.ShouldNotBeEmpty();
			result.ShouldBe(expected);
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