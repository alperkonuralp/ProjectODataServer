using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class TollOperationMapping : IEntityTypeConfiguration<TollOperation>
	{
		public void Configure(EntityTypeBuilder<TollOperation> builder)
		{
			builder.Property(m => m.Price)
				.HasColumnName("Price")
				.IsRequired();
		}
	}
}