using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class TrafficPenaltyOperationMapping : IEntityTypeConfiguration<TrafficPenaltyOperation>
	{
		public void Configure(EntityTypeBuilder<TrafficPenaltyOperation> builder)
		{
			builder.Property(m => m.Price)
				.HasColumnName("Price")
				.IsRequired();

			builder.Property(m => m.Type)
				.HasColumnName("Type")
				.HasMaxLength(32)
				.IsRequired();
		}
	}
}