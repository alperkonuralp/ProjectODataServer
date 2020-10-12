namespace Sample.Data.Entities
{
	public class Customer
	{
		public virtual int Id { get; set; }
		public virtual int AccountId { get; set; }
		public virtual Account Account { get; set; }
	}
}