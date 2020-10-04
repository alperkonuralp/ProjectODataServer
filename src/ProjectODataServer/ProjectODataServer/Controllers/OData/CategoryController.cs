﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;
using System.Net.Http;

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
		public IActionResult Get(int key, ODataQueryOptions<Category> options)
		{
			if (!_db.Set<Category>().Any(x => x.Id == key)) return NotFound();
			return Ok(SingleResult<Category>.Create(_db.Set<Category>().Where(x => x.Id == key)));
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


		[HttpPost]
		public IActionResult Post([FromBody] Category item)
		{
			_db.Set<Category>().Add(item);

			_db.SaveChanges();

			return StatusCode(201, item);
		}



		[HttpPut]
		public IActionResult Put([FromODataUri] int key, [FromBody] Category item)
		{
			var entity = _db.Set<Category>().Find(key);

			if (entity == null) return NotFound();

			if (entity.Name != item.Name) entity.Name = item.Name;

			var a = _db.ChangeTracker.Entries();

			if (a.Any(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified))
				_db.SaveChanges();

			return NoContent();
		}





		[HttpDelete]
		public IActionResult Delete([FromODataUri] int key)
		{
			var entity = _db.Set<Category>().Find(key);

			if (entity == null) return NotFound();

			_db.Set<Category>().Remove(entity);

			_db.SaveChanges();

			return Ok();
		}
	}
}