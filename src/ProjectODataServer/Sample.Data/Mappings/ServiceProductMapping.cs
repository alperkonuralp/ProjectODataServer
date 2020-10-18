using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
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

			var datatime = new System.DateTimeOffset(2020, 10, 18, 13, 36, 00, TimeSpan.FromHours(3));
			builder.HasData(
				new { ProductType = 2, Id = 5, Name = "Azure E03 Virtual Machine", CategoryId = 9, Description = "4VCPU, 8GB Ram Description", LongDescription = "4VCPU, 8GB Ram Long Description", UnitPrice = 0.90, UnitType = ServiceUnitType.Hour, VendorId = 1, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { ProductType = 2, Id = 6, Name = "Oracle Cloud V05 Virtual Machine", CategoryId = 9, Description = "4VCPU, 8GB Ram Description", LongDescription = "4VCPU, 8GB Ram Long Description", UnitPrice = 0.85, UnitType = ServiceUnitType.Hour, VendorId = 2, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { ProductType = 2, Id = 7, Name = "Body Guard Service", CategoryId = 10, Description = "Body Guard Service Description", LongDescription = "Body Guard Service Long Description", UnitPrice = 150.00, UnitType = ServiceUnitType.Hour, VendorId = 8, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 }
				);
		}
	}
}