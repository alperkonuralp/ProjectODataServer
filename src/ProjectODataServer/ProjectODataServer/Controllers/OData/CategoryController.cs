using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly SampleDataDbContext _db;
		private readonly IDateTimeService _dateTimeService;

		public CategoryController(SampleDataDbContext db, ILogger<CategoryController> logger, IDateTimeService dateTimeService)
		{
			_db = db;
			_logger = logger;
			_dateTimeService = dateTimeService;
		}


		[EnableQuery]
		public IQueryable<Category> Get(ODataQueryOptions<Category> options)
		{
			var now = _dateTimeService.Now();
			return _db.Categories;
		}

		[EnableQuery]
		public IActionResult Get(int key, ODataQueryOptions<Category> options)
		{
			if (!_db.Set<Category>().Any(x => x.Id == key))
			{
				_logger.LogError($"The key ({key}) isn't found in the Category table.");
				return NotFound();
			}
			return Ok(SingleResult<Category>.Create(_db.Set<Category>().Where(x => x.Id == key)));
		}

		//[EnableQuery]
		//public IActionResult GetProducts(int key, ODataQueryOptions<Category> options)
		//{
		//	if (!_db.Set<Category>().Any(x => x.Id == key)) return NotFound();

		//	return Ok(_db.Set<Product>().Where(x => x.CategoryId == key));
		//}

		[HttpPost]
		public IActionResult Post([FromBody] Category item)
		{
			_db.Set<Category>().Add(item);

			_db.SaveChanges();

			return StatusCode(201, item);
		}

		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Category item)
		{
			var entity = _db.Set<Category>().Find(key);

			if (entity == null) return NotFound();

			if (entity.Name != item.Name) entity.Name = item.Name;

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();

			return NoContent();
		}

		[HttpPatch]
		public IActionResult Patch([FromODataUri] int key, Delta<Category> item)
		{
			var entity = _db.Set<Category>().Find(key);

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
			var entity = _db.Set<Category>().Find(key);

			if (entity == null) return NotFound();

			_db.Set<Category>().Remove(entity);

			_db.SaveChanges();

			return Ok();
		}
	}
}