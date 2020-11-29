using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectODataServer.Entities
{
	public class Entity<TKey> : IEntity
	{
		public virtual TKey Id { get; set; }
	}
}
