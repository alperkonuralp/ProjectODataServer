using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class ProductMapping : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Product");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("ProductId")
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.HasOne(x => x.Category)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.CategoryId)
				.IsRequired();

			builder.HasData(
				new Product() { Id = 1, CategoryId = 1, Name = "Hamburger" },
				new Product() { Id = 2, CategoryId = 1, Name = "Kuru Fasülye" },
				new Product() { Id = 3, CategoryId = 2, Name = "Kalem" },
				new Product() { Id = 4, CategoryId = 2, Name = "Silgi" }
				);
		}
	}


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


			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("Id")
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.Property(x => x.OperationDateTime).IsRequired();
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.Property(x => x.CreatedBy).IsRequired();
			builder.Property(x => x.ModifiedAt);
			builder.Property(x => x.ModifiedBy);

		}
	}


	public class TollOperationMapping : IEntityTypeConfiguration<TollOperation>
	{
		public void Configure(EntityTypeBuilder<TollOperation> builder)
		{
			builder.Property(m => m.Price)
				.HasColumnName("Price")
				.IsRequired();
		}
	}
	public class AccidentOperationMapping : IEntityTypeConfiguration<AccidentOperation>
	{
		public void Configure(EntityTypeBuilder<AccidentOperation> builder)
		{
			builder.Property(m => m.Type)
				.HasColumnName("Type")
				.HasMaxLength(32)
				.IsRequired();
		}
	}
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
	public class TireOperationMapping : IEntityTypeConfiguration<TireOperation>
	{
		public void Configure(EntityTypeBuilder<TireOperation> builder)
		{
		}
	}
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