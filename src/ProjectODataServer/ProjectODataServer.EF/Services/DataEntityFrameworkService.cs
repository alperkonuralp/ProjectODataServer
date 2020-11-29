using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using ProjectODataServer.Entities;
using ProjectODataServer.Services;
using System.Linq;

namespace ProjectODataServer.EF.Services
{
	public class DataEntityFrameworkService<TEntity, TKey> : IDataService<TEntity, TKey>
		where TEntity : Entity<TKey>
	{
		private readonly ILogger _logger;
		private readonly DbContext _db;

		public DataEntityFrameworkService(DbContext db, ILogger logger)
		{
			_db = db;
			_logger = logger;
		}

		public IQueryable<TEntity> Get()
		{
			return _db.Set<TEntity>();
		}

		public IQueryable<TEntity> Get(TKey key)
		{
			if (!_db.Set<TEntity>().Any(x => x.Id.Equals(key)))
			{
				var msg = $"The key ({key}) isn't found in the {typeof(TEntity).Name} table.";
				_logger.Error(msg);
				throw new NotFoundException(msg);
			}
			return _db.Set<TEntity>().Where(x => x.Id.Equals(key));
		}

		public TEntity Post(TEntity item)
		{
			_db.Set<TEntity>().Add(item);

			_db.SaveChanges();

			return item;
		}

		public void Put(TKey key, TEntity item)
		{
			var entity = _db.Set<TEntity>().Find(key);

			if (entity == null)
			{
				var msg = $"The key ({key}) isn't found in the {typeof(TEntity).Name} table.";
				throw new NotFoundException(msg);
			}

			item.Id = key;

			var entry = _db.Entry(entity);

			entry.CurrentValues.SetValues(item);

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();
		}

		public void Patch(TKey key, IDelta<TEntity> item)
		{
			var entity = _db.Set<TEntity>().Find(key);

			if (entity == null)
			{
				var msg = $"The key ({key}) isn't found in the {typeof(TEntity).Name} table.";
				throw new NotFoundException(msg);
			}

			item.Patch(entity);

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted))
				_db.SaveChanges();
		}

		public void Delete(TKey key)
		{
			var entity = _db.Set<TEntity>().Find(key);

			if (entity == null)
			{
				var msg = $"The key ({key}) isn't found in the {typeof(TEntity).Name} table.";
				throw new NotFoundException(msg);
			}

			_db.Set<TEntity>().Remove(entity);

			_db.SaveChanges();
		}
	}
}