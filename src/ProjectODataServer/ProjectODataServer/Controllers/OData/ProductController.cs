using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class ProductController : SampleControllerBase<Product, int>
	{
		#region Product

		[HttpGet]
		public IActionResult GetName(int key,
															 ODataQueryOptions<Product> options,
															 [FromServices] IDataService<Product, int> dataService)
		{
			return GetProperty(key, dataService, x => x.Name);
		}

		[HttpGet]
		public IActionResult GetUnitPrice(int key,
																		ODataQueryOptions<Product> options,
																		[FromServices] IDataService<Product, int> dataService)
		{
			return GetProperty(key, dataService, x => x.UnitPrice);
		}

		[HttpGet]
		public IActionResult GetVendorId(int key,
																	 ODataQueryOptions<Product> options,
																	 [FromServices] IDataService<Product, int> dataService)
		{
			return GetProperty(key, dataService, x => x.VendorId);
		}

		[HttpGet]
		[EnableQuery]
		public IActionResult GetVendor(int key,
			ODataQueryOptions<Product> options,
			[FromServices] IDataService<Product, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).Select(x => x.Vendor);
				if (!item.Any()) return NotFound();

				return Ok(SingleResult.Create(item));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		#endregion Product

		#region ServiceProduct

		[HttpGet]
		public IActionResult GetDescriptionFromServiceProduct(int key,
																												ODataQueryOptions<Product> options,
																												[FromServices] IDataService<ServiceProduct, int> dataService)
		{
			return GetSubProperty(key, dataService, x => x.Description);
		}

		[HttpGet]
		public IActionResult GetLongDescriptionFromServiceProduct(int key,
																												ODataQueryOptions<Product> options,
																												[FromServices] IDataService<ServiceProduct, int> dataService)
		{
			return GetSubProperty(key, dataService, x => x.LongDescription);
		}

		[HttpGet]
		public IActionResult GetUnitTypeFromServiceProduct(int key,
																												ODataQueryOptions<Product> options,
																												[FromServices] IDataService<ServiceProduct, int> dataService)
		{
			return GetSubProperty(key, dataService, x => x.UnitType);
		}

		[HttpGet]
		public IActionResult GetCategoryIdFromServiceProduct(int key,
																												ODataQueryOptions<Product> options,
																												[FromServices] IDataService<ServiceProduct, int> dataService)
		{
			return GetSubProperty(key, dataService, x => x.CategoryId);
		}


		[HttpGet]
		[EnableQuery]
		public IActionResult GetCategoryFromServiceProduct(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ServiceProduct, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).Select(x => x.Category);
				if (!item.Any()) return NotFound();

				return Ok(SingleResult.Create(item));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}



		[EnableQuery]
		public IActionResult GetFromServiceProduct(ODataQueryOptions<Product> options,
																						 [FromServices] IDataService<ServiceProduct, int> dataService)
		{
			return Ok(dataService.Get());
		}

		[EnableQuery]
		public IActionResult GetServiceProduct(int key,
																				 ODataQueryOptions<Product> options,
																				 [FromServices] IDataService<ServiceProduct, int> dataService)
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



		#endregion ServiceProduct

		#region ShoppingProduct

		[HttpGet]
		public IActionResult GetDescriptionFromShoppingProduct(int key,
																												 ODataQueryOptions<Product> options,
																												 [FromServices] IDataService<ShoppingProduct, int> dataShopping)
		{
			return GetSubProperty(key, dataShopping, x => x.Description);
		}

		[EnableQuery]
		public IActionResult GetFromShoppingProduct(ODataQueryOptions<Product> options,
																							[FromServices] IDataService<ShoppingProduct, int> dataService)
		{
			return Ok(dataService.Get());
		}

		[EnableQuery]
		public IActionResult GetShoppingProduct(int key,
																					ODataQueryOptions<Product> options,
																					[FromServices] IDataService<ShoppingProduct, int> dataService)
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
		public IActionResult GetShortDescriptionFromShoppingProduct(int key,
																												 ODataQueryOptions<Product> options,
																												 [FromServices] IDataService<ShoppingProduct, int> dataShopping)
		{
			return GetSubProperty(key, dataShopping, x => x.ShortDescription);
		}

		[HttpGet]
		public IActionResult GetUnitTypeFromShoppingProduct(int key,
																												 ODataQueryOptions<Product> options,
																												 [FromServices] IDataService<ShoppingProduct, int> dataShopping)
		{
			return GetSubProperty(key, dataShopping, x => x.UnitType);
		}


		[HttpGet]
		public IActionResult GetCategoryIdFromShoppingProduct(int key,
																												 ODataQueryOptions<Product> options,
																												 [FromServices] IDataService<ShoppingProduct, int> dataShopping)
		{
			return GetSubProperty(key, dataShopping, x => x.CategoryId);
		}




		[HttpGet]
		[EnableQuery]
		public IActionResult GetCategoryFromShoppingProduct(int key,
																										 ODataQueryOptions<Product> options,
																										 [FromServices] IDataService<ShoppingProduct, int> dataService)
		{
			try
			{
				var item = dataService.Get(key).Select(x => x.Category);
				if (!item.Any()) return NotFound();

				return Ok(SingleResult.Create(item));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}


		#endregion ShoppingProduct

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