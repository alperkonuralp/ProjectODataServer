using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : SampleControllerBase<Category, int>
	{
		#region Category

		[HttpGet]
		public IActionResult GetName(int key,
															 ODataQueryOptions<Product> options,
															 [FromServices] IDataService<Category, int> dataService)
		{
			return GetProperty(key, dataService, x => x.Name);
		}

		#endregion Category

		#region ServiceCategory

		[EnableQuery]
		public IActionResult GetFromServiceCategory(ODataQueryOptions<Category> options,
																							[FromServices] IDataService<ServiceCategory, int> dataService)
		{
			return Ok(dataService.Get());
		}

		[EnableQuery]
		public IActionResult GetServiceCategory(int key,
																			ODataQueryOptions<Category> options,
																			[FromServices] IDataService<ServiceCategory, int> dataService)
		{
			try
			{
				return Ok(SingleResult.Create(dataService.Get(key)));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetProductsFromServiceCategory(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ServiceCategory, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).SelectMany(x => x.Products);
				if (!item.Any()) return NotFound();

				return Ok(item);
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetParentFromServiceCategory(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ServiceCategory, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).Select(x => x.Parent);
				if (!item.Any()) return NotFound();

				return Ok(SingleResult.Create(item));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetChildrenFromServiceCategory(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ServiceCategory, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).SelectMany(x => x.Children);
				if (!item.Any()) return NotFound();

				return Ok(item);
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}



		[EnableQuery]
		public IActionResult GetWithCategoryFromServiceCategory(int key,
																													 int relatedKey,
																													 ODataQueryOptions<Category> options,
																													 [FromServices] IDataService<ServiceCategory, int> dataService)
		{
			var items = dataService.Get(key).Where(x => x.ParentId == relatedKey);
			if (!items.Any()) return NotFound();

			return Ok(SingleResult.Create(items));
		}

		#endregion ServiceCategory

		#region ShoppingCategory

		[EnableQuery]
		public IActionResult GetFromShoppingCategory(ODataQueryOptions<Category> options,
																					 [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			return Ok(dataService.Get());
		}


		[EnableQuery]
		public IActionResult GetWithCategoryFromShoppingCategory(int key,
																													 int relatedKey,
																													 ODataQueryOptions<Category> options,
																													 [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			var items = dataService.Get(key).Where(x => x.ParentId == relatedKey);
			if (!items.Any()) return NotFound();

			return Ok(SingleResult.Create(items));
		}


		[EnableQuery]
		public IActionResult GetShoppingCategory(int key,
																					 ODataQueryOptions<Category> options,
																					 [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			try
			{
				return Ok(SingleResult.Create(dataService.Get(key)));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetProductsFromShoppingCategory(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).SelectMany(x => x.Products);
				if (!item.Any()) return NotFound();

				return Ok(item);
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetParentFromShoppingCategory(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).Select(x => x.Parent);
				if (!item.Any()) return NotFound();

				return Ok(SingleResult.Create(item));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetChildrenFromShoppingCategory(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).SelectMany(x => x.Children);
				if (!item.Any()) return NotFound();

				return Ok(item);
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		#endregion ShoppingCategory
	}
}