namespace Sample.Data.Entities
{
	public abstract class Product : Entity<int>
	{
		public virtual string Name { get; set; }

		public virtual double UnitPrice { get; set; }

		public virtual int VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }
	}
}