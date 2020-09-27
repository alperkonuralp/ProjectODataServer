using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Data.Entities
{
	public class Category
	{
		public virtual int Id { get; set; }

		public virtual string Name { get; set; }

		public virtual List<Product> Products { get; set; } = new List<Product>();
	}
}
