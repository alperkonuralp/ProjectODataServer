using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class VendorController : ReadonlyEntityODataController<Vendor, int>
	{
		private readonly ILogger _logger;
		private readonly SampleDataDbContext _db;

		public VendorController(SampleDataDbContext db, ILogger<VendorController> logger, ILoggerFactory loggerFactory)
			: base(db, loggerFactory)
		{
			_db = db;
			_logger = logger;
		}

		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Vendor>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.VendorId == key));
		//}

		[HttpPost]
		public IActionResult Post([FromBody] Vendor item)
		{
			_db.Set<Vendor>().Add(item);

			_db.SaveChanges();

			return StatusCode(201, item);
		}

		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Vendor item)
		{
			var entity = _db.Set<Vendor>().Find(key);

			if (entity == null) return NotFound();

			if (entity.Name != item.Name) entity.Name = item.Name;

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();

			return NoContent();
		}

		[HttpPatch]
		public IActionResult Patch([FromODataUri] int key, Delta<Vendor> item)
		{
			var entity = _db.Set<Vendor>().Find(key);

			if (entity == null) return NotFound();

			item.Patch(entity);

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();

			return NoContent();
		}

		[HttpDelete]
		public IActionResult Delete([FromODataUri] int key)
		{
			var entity = _db.Set<Vendor>().Find(key);

			if (entity == null) return NotFound();

			_db.Set<Vendor>().Remove(entity);

			_db.SaveChanges();

			return Ok();
		}
	}
}