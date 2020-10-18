namespace Sample.Data.Entities
{
	public class ServiceProduct : Product
	{
		public string Description { get; set; }
		public string LongDescription { get; set; }
		public virtual ServiceUnitType UnitType { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual ServiceCategory Category { get; set; }
	}
}