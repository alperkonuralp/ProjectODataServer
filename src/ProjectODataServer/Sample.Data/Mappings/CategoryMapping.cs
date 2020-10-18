using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
	public class CategoryMapping : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");

			builder.MapEntityFields<Category, int>("CategoryId");

			builder.MapNameField();

			builder.HasDiscriminator<string>("CategoryType")
				.HasValue<ShoppingCategory>("Shopping")
				.HasValue<ServiceCategory>("Service");

		}
	}
}