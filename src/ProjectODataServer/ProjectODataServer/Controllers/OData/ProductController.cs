using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class ProductController : ControllerBase
	{
		private readonly SampleDataDbContext _db;

		public ProductController(SampleDataDbContext db)
		{
			_db = db;
		}

		[EnableQuery]
		public IQueryable<Product> Get()
		{
			return _db.Products;
		}

		[EnableQuery]
		public SingleResult<Product> Get(int key, ODataQueryOptions<Product> options)
		{
			return SingleResult<Product>.Create(_db.Set<Product>().Where(x => x.Id == key));
		}


		[EnableQuery]
		public SingleResult<Category> GetCategory(int key, ODataQueryOptions<Product> options)
		{
			return SingleResult<Category>.Create(_db.Set<Product>().Include(x=>x.Category).Where(x => x.Id == key).Select(x=>x.Category));
		}
	}
}