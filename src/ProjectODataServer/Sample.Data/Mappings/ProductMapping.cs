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
}