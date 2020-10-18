namespace Sample.Data.Entities
{
	public class ShoppingProduct : Product
	{
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		public virtual ShoppingUnitType UnitType { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual ShoppingCategory Category { get; set; }
	}
}