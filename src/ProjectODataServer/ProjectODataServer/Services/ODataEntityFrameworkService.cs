using Castle.Core.Logging;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Services
{
	public class ODataEntityFrameworkService<TEntity, TKey>
		: IODataService<TEntity, TKey>
		where TEntity : Entity<TKey>
	{
		private readonly ILogger _logger;
		private readonly DbContext _db;

		public ODataEntityFrameworkService(DbContext db, ILogger logger)
		{
			_db = db;
			_logger = logger;
		}

		public IQueryable<TEntity> Get(ODataQueryOptions<TEntity> options)
		{
			return _db.Set<TEntity>();
		}

		public IActionResult Get(TKey key, ODataQueryOptions<TEntity> options)
		{
			if (!_db.Set<TEntity>().Any(x => x.Id.Equals(key)))
			{
				_logger.Error($"The key ({key}) isn't found in the {typeof(TEntity).Name} table.");
				return new NotFoundResult();
			}
			return new OkObjectResult(SingleResult<TEntity>.Create(_db.Set<TEntity>().Where(x => x.Id.Equals(key))));
		}

		public IActionResult Post(TEntity item)
		{
			_db.Set<TEntity>().Add(item);

			_db.SaveChanges();

			return new ObjectResult(item) { StatusCode = 201 };
		}

		public IActionResult Put(TKey key, TEntity item)
		{
			var entity = _db.Set<TEntity>().Find(key);

			if (entity == null) return new NotFoundResult();

			item.Id = key;

			var entry = _db.Entry(entity);

			entry.CurrentValues.SetValues(item);

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();

			return new NoContentResult();
		}

		public IActionResult Patch(TKey key, Delta<TEntity> item)
		{
			var entity = _db.Set<TEntity>().Find(key);

			if (entity == null) return new NotFoundResult();

			item.Patch(entity);

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();

			return new NoContentResult();
		}

		public IActionResult Delete(TKey key)
		{
			var entity = _db.Set<TEntity>().Find(key);

			if (entity == null) return new NotFoundResult();

			_db.Set<TEntity>().Remove(entity);

			_db.SaveChanges();

			return new OkResult();
		}
	}
}