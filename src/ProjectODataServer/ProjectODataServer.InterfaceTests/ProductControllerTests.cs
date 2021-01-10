using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectODataServer.InterfaceTests
{
	public class ProductControllerTests
	{
		[Fact]
		public void Get_WhenRequestToAllItems_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToAllItems_ThenExpectedResult.json",
				(d) =>
				{
					var value = (d["value"] as object[]).Cast<Dictionary<object, object>>();

					foreach (var v in value)
					{
						v.Remove("CreatedAt");
						v.Remove("ModifiedAt");
					}
				});

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToAllItemsOnlyLongDescritionColumn_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product/Sample.ServiceProduct?$select=longDescription",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToAllItemsOnlyLongDescritionColumn_ThenExpectedResult.json");

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProduct_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Sample.ShoppingProduct",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProduct_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Sample.ShoppingProduct/Category",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndDescription_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Sample.ShoppingProduct/Description",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndDescription_ThenExpectedResult.json");

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndUnitType_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Sample.ShoppingProduct/UnitType",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndUnitType_ThenExpectedResult.json");

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndShortDescription_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Sample.ShoppingProduct/ShortDescription",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndShortDescription_ThenExpectedResult.json");

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndName_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Name",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndName_ThenExpectedResult.json");

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndName_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/product(1)/Sample.ShoppingProduct/Name",
				"..\\..\\..\\resultRepository\\ProductControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingProductAndName_ThenExpectedResult.json");

			result.ShouldBeTrue();
		}
	}
}