using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
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

			var datatime = new System.DateTimeOffset(2020, 10, 18, 13, 36, 00, TimeSpan.FromHours(3));
			builder.HasData(
				new { CategoryType = "Shopping", Id = 1, Name = "Foods", ParentId = (int?)null, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Shopping", Id = 2, Name = "TV", ParentId = (int?)null, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Shopping", Id = 3, Name = "Fast Food", ParentId = (int?)1, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Shopping", Id = 4, Name = "Vegitables", ParentId = (int?)1, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Shopping", Id = 5, Name = "Oled TV", ParentId = (int?)2, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Shopping", Id = 6, Name = "Led TV", ParentId = (int?)2, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 }
				);


		}
	}
}