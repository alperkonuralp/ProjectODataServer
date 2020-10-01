using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{
	public class CategoryController : ControllerBase
	{
		private readonly SampleDataDbContext _db;

		public CategoryController(SampleDataDbContext db)
		{
			_db = db;
		}

		[EnableQuery]
		public IQueryable<Category> Get(ODataQueryOptions<Category> options)
		{
			return _db.Categories;
		}

		[EnableQuery]
		public SingleResult<Category> Get(int key, ODataQueryOptions<Category> options)
		{
			return SingleResult<Category>.Create(_db.Set<Category>().Where(x => x.Id == key));
		}

		[EnableQuery]
		public IQueryable<Product> GetProducts(int key, ODataQueryOptions<Category> options)
		{
			//return _db.Set<Category>()
			//	.Include(x=>x.Products)
			//	.FirstOrDefault(x=>x.Id == key)
			//	.Products
			//	.AsQueryable();
			return _db.Set<Product>()
				.Where(x => x.CategoryId == key);
		}
	}
}