using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
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
			var datatime = new System.DateTimeOffset(2020, 10, 18, 13, 36, 00, TimeSpan.FromHours(3));
			builder.HasData(
				new { CategoryType = "Service", Id = 7, Name = "Cloud Services", ParentId = (int?)null, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Service", Id = 8, Name = "Guard Services", ParentId = (int?)null, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Service", Id = 9, Name = "Virtual Machine", ParentId = (int?)7, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { CategoryType = "Service", Id = 10, Name = "Body Guard", ParentId = (int?)8, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 }
				);
		}
	}
}