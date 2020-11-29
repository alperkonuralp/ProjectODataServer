using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : EntityODataController<Category, int>
	{
		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Category>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.CategoryId == key));
		//}
	}
}