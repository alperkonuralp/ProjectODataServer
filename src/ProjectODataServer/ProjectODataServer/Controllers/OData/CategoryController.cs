using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : ReadonlyEntityODataController<Category, int>
	{
		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Category>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.CategoryId == key));
		//}

		[HttpPost]
		public IActionResult Post([FromBody] Category item, [FromServices] IODataService<Category, int> service)
		{
			return service.Post(item);
		}

		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Category item, [FromServices] IODataService<Category, int> service)
		{
			return service.Put(key, item);
		}

		[HttpPatch]
		public IActionResult Patch([FromODataUri] int key, Delta<Category> item, [FromServices] IODataService<Category, int> service)
		{
			return service.Patch(key, item);
		}

		[HttpDelete]
		public IActionResult Delete([FromODataUri] int key, [FromServices] IODataService<Category, int> service)
		{
			return service.Delete(key);
		}
	}
}