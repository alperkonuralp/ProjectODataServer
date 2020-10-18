using System;

namespace Sample.Data.Entities
{
	public interface IEntityBase
	{
		object Id { get; set; }

		DateTimeOffset CreatedAt { get; set; }
		int CreatedBy { get; set; }
		DateTimeOffset ModifiedAt { get; set; }
		int ModifiedBy { get; set; }
	}
}