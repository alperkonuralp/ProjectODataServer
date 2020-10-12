using System;

namespace Sample.Data.Entities
{
	public class Account
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }

		public virtual DateTime CreatedAt { get; set; }
		public virtual int CreatedBy { get; set; }
		public virtual DateTime? ModifiedAt { get; set; }
		public virtual int? ModifiedBy { get; set; }
		public virtual Customer Customer { get; set; }
	}

}