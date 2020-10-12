using System;

namespace Sample.Data.Entities
{
	public class Product
	{
		public virtual int Id { get; set; }

		public virtual string Name { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual Category Category { get; set; }

	}


	public abstract class Operation
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }

		public virtual DateTime OperationDateTime { get; set; }
		public virtual DateTime CreatedAt { get; set; }
		public virtual int CreatedBy { get; set; }
		public virtual DateTime? ModifiedAt { get; set; }
		public virtual int? ModifiedBy { get; set; }
	}

	public class TollOperation : Operation
	{
		public double Price { get; set; }
	}
	public class AccidentOperation : Operation
	{
		public string Type { get; set; }
	}
	public class TrafficPenaltyOperation : Operation
	{
		public double Price { get; set; }
		public string Type { get; set; }
	}
	public class TireOperation : Operation
	{

	}
	public class WinterTireOperation : Operation
	{
		public string DepotLocation { get; set; }
	}
}
