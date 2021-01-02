using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : SampleControllerBase<Category, int>
	{
		[HttpGet]
		public IActionResult GetName(int key, ODataQueryOptions<Product> options, [FromServices] IDataService<Category, int> dataService)
		{
			return GetProperty(key, dataService, x => x.Name);
		}

		[EnableQuery]
		public IActionResult GetFromServiceCategory(ODataQueryOptions<Category> options, [FromServices] IDataService<ServiceCategory, int> dataService)
		{
			return Ok(dataService.Get());
		}

		[EnableQuery]
		public IActionResult GetFromShoppingCategory(ODataQueryOptions<Category> options, [FromServices] IDataService<ShoppingCategory, int> dataService)
		{
			return Ok(dataService.Get());
		}

		[EnableQuery]
		public IActionResult GetServiceCategory(int key, ODataQueryOptions<Category> options, [FromServices] IDataService<ServiceCategory, int> dataService)
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

		[EnableQuery]
		public IActionResult GetShoppingCategory(int key, ODataQueryOptions<Category> options, [FromServices] IDataService<ShoppingCategory, int> dataService)
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

		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Category>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.CategoryId == key));
		//}
	}
}