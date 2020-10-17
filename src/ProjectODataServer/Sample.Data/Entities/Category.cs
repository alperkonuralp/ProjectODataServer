using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Data.Entities
{
	public abstract class Category : Entity<int>
	{
		public virtual string Name { get; set; }

	}

	public class ShoppingCategory : Category
	{

		public virtual int? ParentId { get; set; }
		public virtual ShoppingCategory Parent { get; set; }

		public virtual List<ShoppingCategory> Children { get; set; }

		public virtual List<ShoppingProduct> Products { get; set; } = new List<ShoppingProduct>();

	}
	public class ServiceCategory : Category
	{

		public virtual int? ParentId { get; set; }
		public virtual ServiceCategory Parent { get; set; }

		public virtual List<ServiceCategory> Children { get; set; }
	
		public virtual List<ServiceProduct> Products { get; set; } = new List<ServiceProduct>();
	}
}
