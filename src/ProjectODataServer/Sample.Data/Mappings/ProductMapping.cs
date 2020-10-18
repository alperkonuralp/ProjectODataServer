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

			builder.MapEntityFields<Product, int>("ProductId");

			builder.MapNameField();

			builder.Property(x => x.UnitPrice)
				.IsRequired();

			builder.HasOne(m => m.Vendor)
				.WithMany(m => m.Products)
				.HasForeignKey(m => m.VendorId)
				.IsRequired();

			builder.HasDiscriminator<int>("ProductType")
				.HasValue<ShoppingProduct>(1)
				.HasValue<ServiceProduct>(2);
		}
	}
}