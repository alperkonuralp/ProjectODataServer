using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Entities;
using ProjectODataServer.Services;

namespace ProjectODataServer.WebApi.Controllers
{
	public abstract class EntityODataController<TEntity, TKey> : ReadonlyEntityODataController<TEntity, TKey>
		where TEntity : Entity<TKey>
	{
		protected virtual bool IsEnabledForPost => true;
		protected virtual bool IsEnabledForPut => true;
		protected virtual bool IsEnabledForPatch => true;
		protected virtual bool IsEnabledForDelete => true;

		[HttpPost]
		public virtual IActionResult Post([FromBody] TEntity item, [FromServices] IDataService<TEntity, TKey> service)
		{
			if (!IsEnabledForPost)
				return NotFound();
			return new ObjectResult(service.Post(item)) { StatusCode = 201 };
		}

		[HttpPut]
		public virtual IActionResult Put([FromODataUri] TKey key, [FromBody] TEntity item, [FromServices] IDataService<TEntity, TKey> service)
		{
			if (!IsEnabledForPut)
				return NotFound();

			try
			{
				service.Put(key, item);
				return new NoContentResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}

		[HttpPatch]
		public virtual IActionResult Patch([FromODataUri] TKey key, Microsoft.AspNet.OData.Delta<TEntity> delta, [FromServices] IDataService<TEntity, TKey> service)
		{
			if (!IsEnabledForPatch)
				return NotFound();

			try
			{
				service.Patch(key, new ProjectODataServer.WebApi.Delta<TEntity>(delta));
				return new NoContentResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}

		[HttpDelete]
		public virtual IActionResult Delete([FromODataUri] TKey key, [FromServices] IDataService<TEntity, TKey> service)
		{
			if (!IsEnabledForDelete)
				return NotFound();

			try
			{
				service.Delete(key);
				return new OkResult();
			}
			catch (NotFoundException)
			{
				return new NotFoundResult();
			}
		}
	}
}