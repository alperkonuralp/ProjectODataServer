using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class VendorController : ReadonlyEntityODataController<Vendor, int>
	{
		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Vendor>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.VendorId == key));
		//}

		[HttpPost]
		public IActionResult Post([FromBody] Vendor item, [FromServices] IODataService<Vendor, int> service)
		{
			return service.Post(item);
		}

		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Vendor item, [FromServices] IODataService<Vendor, int> service)
		{
			return service.Put(key, item);
		}

		[HttpPatch]
		public IActionResult Patch([FromODataUri] int key, Delta<Vendor> item, [FromServices] IODataService<Vendor, int> service)
		{
			return service.Patch(key, item);
		}

		[HttpDelete]
		public IActionResult Delete([FromODataUri] int key, [FromServices] IODataService<Vendor, int> service)
		{
			return service.Delete(key);
		}
	}
}