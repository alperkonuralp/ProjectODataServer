using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class VendorController : ReadonlyEntityODataController<Vendor, int>
	{
		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Vendor> options)
		//{
		//	if (!_db.Set<Vendor>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.VendorId == key));
		//}

		[HttpPost]
		public IActionResult Post([FromBody] Vendor item, [FromServices] IDataService<Vendor, int> service)
		{
			return new ObjectResult(service.Post(item)) { StatusCode = 201 };
		}

		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Vendor item, [FromServices] IDataService<Vendor, int> service)
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
		public IActionResult Patch([FromODataUri] int key, Microsoft.AspNet.OData.Delta<Vendor> delta, [FromServices] IDataService<Vendor, int> service)
		{
			try
			{
				service.Patch(key, new ProjectODataServer.WebApi.Delta<Vendor>(delta));
				return new NoContentResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}

		[HttpDelete]
		public IActionResult Delete([FromODataUri] int key, [FromServices] IDataService<Vendor, int> service)
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