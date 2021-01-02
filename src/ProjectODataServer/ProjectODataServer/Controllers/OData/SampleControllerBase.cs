using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ProjectODataServer.Services;
using ProjectODataServer.WebApi.Controllers;
using Sample.Data.Entities;

namespace ProjectODataServer.Controllers.OData
{
	public class SampleControllerBase<TEntity, TKey> : EntityODataController<TEntity, TKey>
		where TEntity : Entity<TKey>
	{
		[HttpGet]
		public IActionResult GetCreatedAt(TKey key
			, ODataQueryOptions<Product> options
			, [FromServices] IDataService<TEntity, TKey> dataService)
		{
			return GetProperty(key, dataService, x => x.CreatedAt);
		}

		[HttpGet]
		public IActionResult GetCreatedBy(TKey key
			, ODataQueryOptions<Product> options
			, [FromServices] IDataService<TEntity, TKey> dataService)
		{
			return GetProperty(key, dataService, x => x.CreatedBy);
		}

		[HttpGet]
		public IActionResult GetModifiedAt(TKey key
			, ODataQueryOptions<Product> options
			, [FromServices] IDataService<TEntity, TKey> dataService)
		{
			return GetProperty(key, dataService, x => x.ModifiedAt);
		}

		[HttpGet]
		public IActionResult GetModifiedBy(TKey key
			, ODataQueryOptions<Product> options
			, [FromServices] IDataService<TEntity, TKey> dataService)
		{
			return GetProperty(key, dataService, x => x.ModifiedBy);
		}
	}
}