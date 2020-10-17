using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Data.Entities
{
	public abstract class Entity<TKey>
	{
		public virtual TKey Id { get; set; }

		public virtual DateTimeOffset CreatedAt { get; set; }
		public virtual int CreatedBy { get; set; }
		public virtual DateTimeOffset ModifiedAt { get; set; }
		public virtual int ModifiedBy { get; set; }
	}
}
