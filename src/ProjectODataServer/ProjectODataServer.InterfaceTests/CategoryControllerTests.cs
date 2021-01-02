using MessagePack;
using Shouldly;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Xunit;

namespace ProjectODataServer.InterfaceTests
{
	public class CategoryControllerTests
	{
		[Fact]
		public void Get_WhenRequestToAllItems_ThenExpectedResult()
		{
			var result = GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category\",\"value\":[{\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"Foods\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":1,\"ParentId\":null},{\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"TV\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":2,\"ParentId\":null},{\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"Fast Food\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":3,\"ParentId\":1},{\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"Vegitables\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":4,\"ParentId\":1},{\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"Oled TV\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":5,\"ParentId\":2},{\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"Led TV\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":6,\"ParentId\":2},{\"@odata.type\":\"#Sample.ServiceCategory\",\"Name\":\"Cloud Services\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":7,\"ParentId\":null},{\"@odata.type\":\"#Sample.ServiceCategory\",\"Name\":\"Guard Services\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":8,\"ParentId\":null},{\"@odata.type\":\"#Sample.ServiceCategory\",\"Name\":\"Virtual Machine\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":9,\"ParentId\":7},{\"@odata.type\":\"#Sample.ServiceCategory\",\"Name\":\"Body Guard\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":10,\"ParentId\":8}]}");

			var ms = new MemoryStream(MessagePackSerializer.ConvertFromJson(result));

			var resultDictionary = MessagePackSerializer.Typeless.Deserialize(ms, MessagePackSerializerOptions.Standard) as Dictionary<object, object>;

			resultDictionary.ShouldNotBeNull();
			resultDictionary.ShouldNotBeEmpty();
			resultDictionary.Count.ShouldBe(2);
			resultDictionary.ContainsKey("@odata.context").ShouldBeTrue();
			resultDictionary["@odata.context"].ShouldBe("https://localhost:5001/odata/$metadata#Category");
			resultDictionary.ContainsKey("value").ShouldBeTrue();
			resultDictionary["value"].ShouldNotBeNull();
			resultDictionary["value"].ShouldBeOfType<object[]>();
			var value = resultDictionary["value"] as object[];
			value.Length.ShouldBe(10);
			value[0].ShouldNotBeNull();
			value[0].ShouldBeOfType<Dictionary<object, object>>();

			var item = value[0] as Dictionary<object, object>;
			item.ShouldNotBeNull();
			item.Count.ShouldBe(8);
			item["@odata.type"].ShouldBe("#Sample.ShoppingCategory");
			item["Name"].ShouldBe("Foods");
			item["Id"].ShouldBe(1);
			item["ParentId"].ShouldBeNull();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory/$entity\",\"@odata.type\":\"#Sample.ShoppingCategory\",\"Name\":\"Foods\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":1,\"ParentId\":null}");
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)/Sample.ShoppingCategory",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory/$entity\",\"Name\":\"Foods\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":1,\"ParentId\":null}");
		}

		[Fact]
		public void Get_WhenRequestToItemChildrenWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)/Sample.ShoppingCategory/Children",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory\",\"value\":[{\"Name\":\"Fast Food\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":3,\"ParentId\":1},{\"Name\":\"Vegitables\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":4,\"ParentId\":1}]}");
		}

		[Fact]
		public void Get_WhenRequestToItemChild3WhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)/Sample.ShoppingCategory/Children(3)",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory/$entity\",\"Name\":\"Fast Food\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":3,\"ParentId\":1}");
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs7_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(7)",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ServiceCategory/$entity\",\"@odata.type\":\"#Sample.ServiceCategory\",\"Name\":\"Cloud Services\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":7,\"ParentId\":null}");
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(7)/Sample.ServiceCategory",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ServiceCategory/$entity\",\"Name\":\"Cloud Services\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":7,\"ParentId\":null}");
		}

		[Fact]
		public void Get_WhenRequestToItemChildrenWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult()
		{
			GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(7)/Sample.ServiceCategory/Children",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ServiceCategory\",\"value\":[{\"Name\":\"Virtual Machine\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":9,\"ParentId\":7}]}");
		}

		protected string GetAndCompareResultFromWebRequest(string address, string expectedResult)
		{
			var webClient = new WebClient();

			var result = webClient.DownloadString(address);

			result.ShouldNotBeEmpty();
			result.ShouldBe(expectedResult);

			return result;
		}
	}
}