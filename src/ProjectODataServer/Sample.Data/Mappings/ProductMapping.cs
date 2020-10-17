using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class VendorMapping : IEntityTypeConfiguration<Vendor>
	{
		public void Configure(EntityTypeBuilder<Vendor> builder)
		{
			builder.ToTable("Vendor");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("VendorId")
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.IsRequired();
			builder.Property(x => x.CreatedBy)
				.IsRequired();
			builder.Property(x => x.ModifiedAt)
				.IsRequired();
			builder.Property(x => x.ModifiedBy)
				.IsRequired();
		}
	}

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

			builder.Property(x => x.UnitPrice)
				.IsRequired();

			builder.HasOne(m => m.Vendor)
				.WithMany(m => m.Products)
				.HasForeignKey(m => m.VendorId)
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.IsRequired();
			builder.Property(x => x.CreatedBy)
				.IsRequired();
			builder.Property(x => x.ModifiedAt)
				.IsRequired();
			builder.Property(x => x.ModifiedBy)
				.IsRequired();

			builder.HasDiscriminator<int>("ProductType")
				.HasValue<ShoppingProduct>(1)
				.HasValue<ServiceProduct>(2);
		}
	}

	public class ShoppingProductMapping : IEntityTypeConfiguration<ShoppingProduct>
	{
		public void Configure(EntityTypeBuilder<ShoppingProduct> builder)
		{
			builder.Property(m => m.Description)
				.HasColumnName("Description")
				.HasMaxLength(2000)
				.IsRequired();

			builder.Property(m => m.ShortDescription)
				.HasMaxLength(2000)
				.IsRequired();

			builder.Property(m => m.UnitType)
				.IsRequired()
				.HasColumnName("UnitType")
				.HasConversion<byte>();

			builder.Property(m => m.CategoryId)
				.HasColumnName("CategoryId")
				.IsRequired();

			builder.HasOne(m => m.Category)
				.WithMany(m => m.Products)
				.HasForeignKey(m => m.CategoryId)
				.IsRequired();
		}
	}

	public class ServiceProductMapping : IEntityTypeConfiguration<ServiceProduct>
	{
		public void Configure(EntityTypeBuilder<ServiceProduct> builder)
		{
			builder.Property(m => m.Description)
				.HasColumnName("Description")
				.HasMaxLength(2000)
				.IsRequired();

			builder.Property(m => m.LongDescription)
				.HasMaxLength(2000)
				.IsRequired(false);

			builder.Property(m => m.UnitType)
				.IsRequired()
				.HasColumnName("UnitType")
				.HasConversion<byte>();

			builder.Property(m => m.CategoryId)
				.HasColumnName("CategoryId")
				.IsRequired();

			builder.HasOne(m => m.Category)
				.WithMany(m => m.Products)
				.HasForeignKey(m => m.CategoryId)
				.IsRequired();
		}
	}
}