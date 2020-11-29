using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;
using System;

namespace ProjectODataServer.Controllers.OData
{
	public class VendorController : EntityODataController<Vendor, int>
	{
		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Vendor> options)
		//{
		//	if (!_db.Set<Vendor>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.VendorId == key));
		//}

		protected override bool IsEnabledForPut => false;
		protected override bool IsEnabledForPatch => false;

		//public override IActionResult Patch([FromODataUri] int key, Delta<Vendor> delta, [FromServices] IDataService<Vendor, int> service)
		//{
		//	return NotFound();
		//}
	}
}