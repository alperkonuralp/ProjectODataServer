using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectODataServer.InterfaceTests
{
	public class VendorControllerTests
	{
		[Fact]
		public void Get_WhenRequestToAllItems_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToAllItems_ThenExpectedResult.json",
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
		public void Get_WhenRequestToAllItemsToOrderedByName_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor?$orderby=name",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToAllItemsToOrderedByName_ThenExpectedResult.json",
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
		public void Get_WhenRequestToAllItemsForOnlyNameColumn_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor?$select=name",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToAllItemsForOnlyNameColumn_ThenExpectedResult.json"
				);

			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemNameWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/name",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemNameWhichIdIs1_ThenExpectedResult.json");
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemNameWhichIdIs1AndOnlyValue_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareStringResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/Name/$value",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemNameWhichIdIs1AndOnlyValue_ThenExpectedResult.txt");
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemCreatedByWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/CreatedBy",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemCreatedByWhichIdIs1_ThenExpectedResult.json");
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemCreatedAtWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/CreatedAt",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemCreatedAtWhichIdIs1_ThenExpectedResult.json");
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemModifiedByWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/ModifiedBy",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemModifiedByWhichIdIs1_ThenExpectedResult.json");
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemModifiedAtWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/ModifiedAt",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemModifiedAtWhichIdIs1_ThenExpectedResult.json");
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1ToProducts_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/products",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemWhichIdIs1ToProducts_ThenExpectedResult.json",
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
		public void Get_WhenRequestToItemProducts1WhichIdIs5AndTypeIsServiceCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/vendor(1)/products(5)",
				"..\\..\\..\\resultRepository\\VendorControllerTests-Get_WhenRequestToItemProducts1WhichIdIs5AndTypeIsServiceCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}
	}
}