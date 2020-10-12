using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class TireOperationMapping : IEntityTypeConfiguration<TireOperation>
	{
		public void Configure(EntityTypeBuilder<TireOperation> builder)
		{
			builder.HasOne(m => m.Supplier)
				.WithMany(m=>m.TireOperations)
				.HasForeignKey(m => m.SupplierId)
				.IsRequired();
		}
	}
}