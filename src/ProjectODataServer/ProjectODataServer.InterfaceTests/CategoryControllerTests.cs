using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectODataServer.InterfaceTests
{
	public class CategoryControllerTests
	{
		[Fact]
		public void Get_WhenRequestToAllItems_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToAllItems_ThenExpectedResult.json",
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
		public void Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(1)",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(1)/Sample.ShoppingCategory",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemChildrenWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(1)/Sample.ShoppingCategory/Children",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemChildrenWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult.json",
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
		public void Get_WhenRequestToItemChild3WhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(1)/Sample.ShoppingCategory/Children(3)",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemChild3WhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs7_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(7)",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemWhichIdIs7_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(7)/Sample.ServiceCategory",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}

		[Fact]
		public void Get_WhenRequestToItemChildrenWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(7)/Sample.ServiceCategory/Children",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemChildrenWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult.json",
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
		public void Get_WhenRequestToItemChild7WhichIdIs9AndTypeIsServiceCategory_ThenExpectedResult()
		{
			var result = TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(7)/Sample.ServiceCategory/Children(9)",
				"..\\..\\..\\resultRepository\\CategoryControllerTests-Get_WhenRequestToItemChild7WhichIdIs9AndTypeIsServiceCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
			result.ShouldBeTrue();
		}
	}
	}