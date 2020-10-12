using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class WinterTireOperationMapping : IEntityTypeConfiguration<WinterTireOperation>
	{
		public void Configure(EntityTypeBuilder<WinterTireOperation> builder)
		{

			builder.Property(m => m.DepotLocation)
				.HasColumnName("DepotLocation")
				.IsRequired();
		}
	}
}