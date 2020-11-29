using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class ProductController : ReadonlyEntityODataController<Product, int>
	{
		//[EnableQuery]
		//public IActionResult GetCategory(int key, ODataQueryOptions<Product> options)
		//{
		//	if (!_db.Set<Product>().Any(x => x.Id == key)) return NotFound();
		//	return Ok(SingleResult.Create(_db.Set<Product>().Include(x => x.Category).Where(x => x.Id == key).Select(x => x.Category)));
		//}

		//[HttpPost]
		//public IActionResult Post([FromBody] Product item)
		//{
		//	if (item == null) return NotFound("Product item not found.");
		//	if (item.CategoryId == 0 && item.Category == null) return NotFound("Category information not found.");

		//	_db.Set<Product>().Add(item);

		//	_db.SaveChanges();

		//	return StatusCode(201, item);
		//}

		//[HttpPut]
		//public IActionResult Put([FromODataUri] int key, [FromBody] Product item)
		//{
		//	if (item == null) return NotFound("Product item not found.");
		//	if (item.CategoryId == 0 && item.Category == null) return NotFound("Category information not found.");

		//	var entity = _db.Set<Product>().Find(key);

		//	if (entity == null) return NotFound();

		//	if (entity.Name != item.Name) entity.Name = item.Name;
		//	if (item.CategoryId != 0)
		//	{
		//		if (entity.CategoryId != item.CategoryId) entity.CategoryId = item.CategoryId;
		//	}
		//	else
		//	{
		//		if(item.Category != null)
		//		{
		//			entity.CategoryId = 0;
		//			entity.Category = item.Category;
		//		}
		//	}

		//	var a = _db.ChangeTracker.Entries();

		//	if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
		//		_db.SaveChanges();

		//	return NoContent();
		//}

		//[HttpPatch]
		//public IActionResult Patch([FromODataUri] int key, Delta<Product> item)
		//{
		//	var entity = _db.Set<Product>().Find(key);

		//	if (entity == null) return NotFound();

		//	item.Patch(entity);

		//	var a = _db.ChangeTracker.Entries();

		//	if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
		//		_db.SaveChanges();

		//	return NoContent();
		//}

		//[HttpDelete]
		//public IActionResult Delete([FromODataUri] int key)
		//{
		//	var entity = _db.Set<Product>().Find(key);

		//	if (entity == null) return NotFound();

		//	_db.Set<Product>().Remove(entity);

		//	_db.SaveChanges();

		//	return Ok();
		//}
	}
}