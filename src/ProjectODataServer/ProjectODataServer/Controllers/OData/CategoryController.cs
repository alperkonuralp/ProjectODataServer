using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public IQueryable<Category> Get()
		{
			return _db.Categories;
		}
	}
}
