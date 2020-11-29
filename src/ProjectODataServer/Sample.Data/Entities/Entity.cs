using System;

namespace Sample.Data.Entities
{
	public abstract class Entity<TKey> : ProjectODataServer.Entities.Entity<TKey>, IEntityBase
	{
		public virtual DateTimeOffset CreatedAt { get; set; }
		public virtual int CreatedBy { get; set; }
		public virtual DateTimeOffset ModifiedAt { get; set; }
		public virtual int ModifiedBy { get; set; }

		object IEntityBase.Id { get => Id; set => Id = (TKey)value; }
	}
}