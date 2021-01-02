using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;
using Sample.Data.Services;

namespace ProjectODataServer.Controllers.OData
{
	public class VendorController : SampleControllerBase<Vendor, int>
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

		[HttpGet]
		public IActionResult GetName(int key, ODataQueryOptions<Product> options, [FromServices] IDataService<Vendor, int> dataService)
		{
			return GetProperty(key, dataService, x => x.Name);
		}

		protected override bool IsEnabledForPut => false;
		protected override bool IsEnabledForPatch => false;
	}
}