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
		public IActionResult Post([FromBody] Category item, [FromServices] IDataService<Category, int> service)
		{
			return new ObjectResult(service.Post(item)) { StatusCode = 201 };
		}

		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Category item, [FromServices] IDataService<Category, int> service)
		{
			try
			{
				service.Put(key, item);
				return new NoContentResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}

		[HttpPatch]
		public IActionResult Patch([FromODataUri] int key, Microsoft.AspNet.OData.Delta<Category> delta, [FromServices] IDataService<Category, int> service)
		{
			try
			{
				service.Patch(key, new Delta<Category>(delta));
				return new NoContentResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}

		[HttpDelete]
		public IActionResult Delete([FromODataUri] int key, [FromServices] IDataService<Category, int> service)
		{
			try
			{
				service.Delete(key);
				return new OkResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}
	}
}