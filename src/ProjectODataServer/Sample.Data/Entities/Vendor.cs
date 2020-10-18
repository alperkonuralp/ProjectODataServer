using System.Collections.Generic;

namespace Sample.Data.Entities
{
	public class Vendor : Entity<int>
	{
		public virtual string Name { get; set; }

		public virtual List<Product> Products { get; set; } = new List<Product>();
	}
}