namespace Sample.Data.Entities
{
	public abstract class Category : Entity<int>
	{
		public virtual string Name { get; set; }
	}
}