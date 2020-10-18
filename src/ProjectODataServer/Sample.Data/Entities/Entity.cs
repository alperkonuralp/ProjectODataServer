using System;

namespace Sample.Data.Entities
{
	public abstract class Entity<TKey> : IEntityBase
	{
		public virtual TKey Id { get; set; }

		public virtual DateTimeOffset CreatedAt { get; set; }
		public virtual int CreatedBy { get; set; }
		public virtual DateTimeOffset ModifiedAt { get; set; }
		public virtual int ModifiedBy { get; set; }

		object IEntityBase.Id { get => Id; set => Id = (TKey)value; }
	}
}