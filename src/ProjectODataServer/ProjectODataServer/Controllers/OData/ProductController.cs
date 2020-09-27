//using Microsoft.AspNet.OData;
//using Microsoft.AspNetCore.Mvc;
//using Sample.Data.DbContexts;
//using Sample.Data.Entities;
//using System.Linq;

//namespace ProjectODataServer.Controllers.OData
//{
//	public class ProductController : ControllerBase
//	{
//		private readonly SampleDataDbContext _db;

//		public ProductController(SampleDataDbContext db)
//		{
//			_db = db;
//		}

//		[EnableQuery]
//		public IQueryable<Product> Get()
//		{
//			return _db.Products;
//		}
//	}
//}
