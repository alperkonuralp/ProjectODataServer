using MessagePack;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Xunit;

namespace ProjectODataServer.InterfaceTests
{
	public class CategoryControllerTests
	{
		[Fact]
		public void Get_WhenRequestToAllItems_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category",
				"Get_WhenRequestToAllItems_ThenExpectedResult.json",
				(d) =>
				{

					var value = (d["value"] as object[]).Cast<Dictionary<object, object>>();

					foreach (var v in value)
					{
						v.Remove("CreatedAt");
						v.Remove("ModifiedAt");
					}
				});
		}


		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(1)",
				"Get_WhenRequestToAllItems_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			//TestHelperService.GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)/Sample.ShoppingCategory",
			//															 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory/$entity\",\"Name\":\"Foods\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":1,\"ParentId\":null}");

			TestHelperService.GetAndCompareResultFromWebRequestAndStoredData(
				"https://localhost:5001/odata/category(1)/Sample.ShoppingCategory",
				"Get_WhenRequestToItemWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult.json",
				(d) =>
				{
					d.Remove("CreatedAt");
					d.Remove("ModifiedAt");
				});

		}

		[Fact]
		public void Get_WhenRequestToItemChildrenWhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)/Sample.ShoppingCategory/Children",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory\",\"value\":[{\"Name\":\"Fast Food\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":3,\"ParentId\":1},{\"Name\":\"Vegitables\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":4,\"ParentId\":1}]}");
		}

		[Fact]
		public void Get_WhenRequestToItemChild3WhichIdIs1AndTypeIsShoppingCategory_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(1)/Sample.ShoppingCategory/Children(3)",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ShoppingCategory/$entity\",\"Name\":\"Fast Food\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":3,\"ParentId\":1}");
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs7_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(7)",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ServiceCategory/$entity\",\"@odata.type\":\"#Sample.ServiceCategory\",\"Name\":\"Cloud Services\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":7,\"ParentId\":null}");
		}

		[Fact]
		public void Get_WhenRequestToItemWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(7)/Sample.ServiceCategory",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ServiceCategory/$entity\",\"Name\":\"Cloud Services\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":7,\"ParentId\":null}");
		}

		[Fact]
		public void Get_WhenRequestToItemChildrenWhichIdIs7AndTypeIsServiceCategory_ThenExpectedResult()
		{
			TestHelperService.GetAndCompareResultFromWebRequest("https://localhost:5001/odata/category(7)/Sample.ServiceCategory/Children",
																		 "{\"@odata.context\":\"https://localhost:5001/odata/$metadata#Category/Sample.ServiceCategory\",\"value\":[{\"Name\":\"Virtual Machine\",\"CreatedAt\":\"2020-10-18T13:36:00+03:00\",\"CreatedBy\":-1,\"ModifiedAt\":\"2020-10-18T13:36:00+03:00\",\"ModifiedBy\":-1,\"Id\":9,\"ParentId\":7}]}");
		}

	}
}