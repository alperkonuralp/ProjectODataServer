using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public abstract class ReadonlyEntityODataController<TEntity, TKey> : ControllerBase
		where TEntity : Entity<TKey>
	{
		[EnableQuery]
		public IQueryable<TEntity> Get(ODataQueryOptions<TEntity> options, [FromServices] IODataService<TEntity, TKey> service)
		{
			return service.Get(options);
		}

		[EnableQuery]
		public IActionResult Get(TKey key, ODataQueryOptions<TEntity> options, [FromServices] IODataService<TEntity, TKey> service)
		{
			return service.Get(key, options);
		}
	}
}