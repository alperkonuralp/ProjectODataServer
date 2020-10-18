using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public abstract class ReadonlyEntityODataController<TEntity, TKey> : ControllerBase
		where TEntity : Entity<TKey>
	{
		private readonly ILogger _logger;
		private readonly DbContext _db;

		public ReadonlyEntityODataController(SampleDataDbContext db, ILoggerFactory loggerFactory)
		{
			_db = db;
			_logger = loggerFactory.CreateLogger(this.GetType().Name);
		}


		[EnableQuery]
		public IQueryable<TEntity> Get(ODataQueryOptions<TEntity> options)
		{
			return _db.Set<TEntity>();
		}

		[EnableQuery]
		public IActionResult Get(int key, ODataQueryOptions<TEntity> options)
		{
			if (!_db.Set<TEntity>().Any(x => x.Id.Equals(key)))
			{
				_logger.LogError($"The key ({key}) isn't found in the {typeof(TEntity).Name} table.");
				return NotFound();
			}
			return Ok(SingleResult<TEntity>.Create(_db.Set<TEntity>().Where(x => x.Id.Equals(key))));
		}


	}
}