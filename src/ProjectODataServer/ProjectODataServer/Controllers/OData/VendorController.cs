using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;
using Sample.Data.Services;

namespace ProjectODataServer.Controllers.OData
{
	public class VendorController : EntityODataController<Vendor, int>
	{
		[EnableQuery]
		public IActionResult GetProducts(int key, [FromServices] IVendorDataService vendorDataService)
		{
			try
			{
				return Ok(vendorDataService.GetProducts(key));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		protected override bool IsEnabledForPut => false;
		protected override bool IsEnabledForPatch => false;
	}
}