namespace Sample.Data.Entities
{
	public class TireOperation : Operation
	{

		public virtual int SupplierId { get; set; }
		public virtual Supplier Supplier { get; set; }
	}
}
