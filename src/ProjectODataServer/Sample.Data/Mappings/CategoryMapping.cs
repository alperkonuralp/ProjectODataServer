using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class CategoryMapping : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("CategoryId")
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.IsRequired();
			builder.Property(x => x.CreatedBy)
				.IsRequired();
			builder.Property(x => x.ModifiedAt)
				.IsRequired();
			builder.Property(x => x.ModifiedBy)
				.IsRequired();


			builder.Property(x => x.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.HasDiscriminator<string>("CategoryType")
				.HasValue<ShoppingCategory>("Shopping")
				.HasValue<ServiceCategory>("Service");
		}
	}


	public class ShoppingCategoryMapping : IEntityTypeConfiguration<ShoppingCategory>
	{
		public void Configure(EntityTypeBuilder<ShoppingCategory> builder)
		{
			builder.Property(m => m.ParentId)
				.HasColumnName("ParentId")
				.IsRequired(false);

			builder.HasOne(m => m.Parent)
				.WithMany(m => m.Children)
				.HasForeignKey("ParentId")
				.IsRequired(false)
				;

		}
	}
	public class ServiceCategoryMapping : IEntityTypeConfiguration<ServiceCategory>
	{
		public void Configure(EntityTypeBuilder<ServiceCategory> builder)
		{
			builder.Property(m => m.ParentId)
				.HasColumnName("ParentId")
				.IsRequired(false);

			builder.HasOne(m => m.Parent)
				.WithMany(m => m.Children)
				.HasForeignKey("ParentId")
				.IsRequired(false)
				;

		}
	}
}