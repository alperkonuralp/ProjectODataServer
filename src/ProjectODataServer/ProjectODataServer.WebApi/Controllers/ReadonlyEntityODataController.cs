using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Entities;
using ProjectODataServer.Services;
using System;
using System.Linq;

namespace ProjectODataServer.WebApi.Controllers
{
	public abstract class ReadonlyEntityODataController<TEntity, TKey> : ControllerBase
		where TEntity : Entity<TKey>
	{
		[EnableQuery]
		public virtual IQueryable<TEntity> Get(ODataQueryOptions<TEntity> options, [FromServices] IDataService<TEntity, TKey> service)
		{
			return service.Get();
		}

		[HttpGet]
		[EnableQuery]
		public virtual IActionResult Get(TKey key, ODataQueryOptions<TEntity> options, [FromServices] IDataService<TEntity, TKey> service)
		{
			try
			{
				return new OkObjectResult(SingleResult<TEntity>.Create(service.Get(key)));
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}

		protected IActionResult GetProperty<TResult>(TKey key,
			IDataService<TEntity, TKey> dataService,
			Func<TEntity, TResult> expression)
		{
			var item = dataService.Get(key).Select(expression);
			if (!item.Any()) return NotFound();
			return Ok(item.FirstOrDefault());
		}
		protected IActionResult GetSubProperty<TSubEntity, TSubKey, TResult>(TSubKey key,
			IDataService<TSubEntity, TSubKey> dataService,
			Func<TSubEntity, TResult> expression)
			where TSubEntity: Entity<TSubKey>
		{
			var item = dataService.Get(key).Select(expression);
			if (!item.Any()) return NotFound();
			return Ok(item.FirstOrDefault());
		}
	}
}