using System;
using System.Collections.Generic;

namespace Sample.Data.Entities
{
	public class Supplier : Company
	{
		public virtual string Type { get; set; }
		public virtual List<TireOperation> TireOperations { get; set; } = new List<TireOperation>();
	}
}
