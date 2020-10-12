using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class OperationMapping : IEntityTypeConfiguration<Operation>
	{
		public void Configure(EntityTypeBuilder<Operation> builder)
		{
			builder.ToTable("Operation");
			builder.HasDiscriminator<string>("OperationType")
				.HasValue<TollOperation>(nameof(TollOperation))
				.HasValue<AccidentOperation>(nameof(AccidentOperation))
				.HasValue<TrafficPenaltyOperation>(nameof(TrafficPenaltyOperation))
				.HasValue<TireOperation>(nameof(TireOperation))
				.HasValue<WinterTireOperation>(nameof(WinterTireOperation))
				;


			builder.HasKey(m => m.Id);
			builder.Property(m => m.Id)
				.HasColumnName("Id")
				.IsRequired();

			builder.Property(m => m.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.Property(m => m.OperationDateTime).IsRequired();
			builder.Property(m => m.CreatedAt).IsRequired();
			builder.Property(m => m.CreatedBy).IsRequired();
			builder.Property(m => m.ModifiedAt);
			builder.Property(m => m.ModifiedBy);

			builder.HasOne(m => m.Account)
				.WithMany()
				.HasForeignKey(m => m.AccountId)
				.IsRequired();
		}
	}
}