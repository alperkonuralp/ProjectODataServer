using System.Collections.Generic;

namespace Sample.Data.Entities
{
	public class ShoppingCategory : Category
	{

		public virtual int? ParentId { get; set; }
		public virtual ShoppingCategory Parent { get; set; }

		public virtual List<ShoppingCategory> Children { get; set; }

		public virtual List<ShoppingProduct> Products { get; set; } = new List<ShoppingProduct>();

	}
}
