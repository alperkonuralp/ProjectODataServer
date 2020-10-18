using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Services
{
	public interface IODataService<TEntity, TKey> where TEntity : Entity<TKey>
	{
		IActionResult Delete(TKey key);

		IActionResult Get(TKey key, ODataQueryOptions<TEntity> options);

		IQueryable<TEntity> Get(ODataQueryOptions<TEntity> options);

		IActionResult Patch(TKey key, Delta<TEntity> item);

		IActionResult Post(TEntity item);

		IActionResult Put(TKey key, TEntity item);
	}
}