using System.Collections.Generic;

namespace Sample.Data.Entities
{
	public class ServiceCategory : Category
	{

		public virtual int? ParentId { get; set; }
		public virtual ServiceCategory Parent { get; set; }

		public virtual List<ServiceCategory> Children { get; set; }
	
		public virtual List<ServiceProduct> Products { get; set; } = new List<ServiceProduct>();
	}
}
