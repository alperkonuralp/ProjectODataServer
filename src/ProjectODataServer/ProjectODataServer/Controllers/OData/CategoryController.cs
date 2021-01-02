using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : SampleControllerBase<Category, int>
	{


		[HttpGet]
		public IActionResult GetName(int key, ODataQueryOptions<Product> options, [FromServices] IDataService<Category, int> dataService)
		{
			return GetProperty(key, dataService, x => x.Name);
		}

		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Category>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.CategoryId == key));
		//}
	}
}