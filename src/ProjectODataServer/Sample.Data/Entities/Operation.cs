using System;

namespace Sample.Data.Entities
{
	public abstract class Operation
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }

		public virtual int AccountId { get; set; }
		public virtual Account Account { get; set; }

		public virtual DateTime OperationDateTime { get; set; }
		public virtual DateTime CreatedAt { get; set; }
		public virtual int CreatedBy { get; set; }
		public virtual DateTime? ModifiedAt { get; set; }
		public virtual int? ModifiedBy { get; set; }
	}
}
