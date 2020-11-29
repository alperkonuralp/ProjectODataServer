using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Entities;
using ProjectODataServer.Services;
using System.Linq;

namespace ProjectODataServer.WebApi.Controllers
{
	public abstract class ReadonlyEntityODataController<TEntity, TKey> : ControllerBase
		where TEntity : Entity<TKey>
	{
		[EnableQuery]
		public IQueryable<TEntity> Get(ODataQueryOptions<TEntity> options, [FromServices] IDataService<TEntity, TKey> service)
		{
			return service.Get();
		}

		[EnableQuery]
		public IActionResult Get(TKey key, ODataQueryOptions<TEntity> options, [FromServices] IDataService<TEntity, TKey> service)
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
	}
}