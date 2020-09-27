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

			builder.Property(x => x.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.HasData(
				new Category() { Id = 1, Name = "Yiyecek" },
				new Category() { Id = 2, Name = "Kırtasiye" }
				);
		}
	}
}