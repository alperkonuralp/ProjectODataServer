using System.Collections.Generic;

namespace Sample.Data.Entities
{
	public abstract class Product : Entity<int>
	{
		public virtual string Name { get; set; }

		public virtual double UnitPrice { get; set; }

		public virtual int VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }
	}

	public class Vendor : Entity<int>
	{
		public virtual string Name { get; set; }

		public virtual List<Product> Products { get; set; } = new List<Product>();
	}

	public enum ShoppingUnitType : byte
	{
		Item = 0,
		Set = 1,
		Kilogram = 10,
		Metre = 11,
		Volume = 12
	}

	public enum ServiceUnitType : byte
	{
		Item = 0,
		Set = 1,
		Hour = 20,
	}

	public class ShoppingProduct : Product
	{
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		public virtual ShoppingUnitType UnitType { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual ShoppingCategory Category { get; set; }
	}

	public class ServiceProduct : Product
	{
		public string Description { get; set; }
		public string LongDescription { get; set; }
		public virtual ServiceUnitType UnitType { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual ServiceCategory Category { get; set; }
	}
}