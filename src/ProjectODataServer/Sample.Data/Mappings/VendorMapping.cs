using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
	public class VendorMapping : IEntityTypeConfiguration<Vendor>
	{
		public void Configure(EntityTypeBuilder<Vendor> builder)
		{
			builder.ToTable("Vendor");

			builder.MapEntityFields<Vendor, int>("VendorId");
			builder.MapNameField();

			var datatime = new System.DateTimeOffset(2020, 10, 18, 13, 36, 00, TimeSpan.FromHours(3));
			builder.HasData(
				new Vendor() { Id = 1, Name = "Microsoft", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 2, Name = "Oracle", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 3, Name = "Apple", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 4, Name = "Mc Donalts", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 5, Name = "Migros", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 6, Name = "Sony", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 7, Name = "Lg", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new Vendor() { Id = 8, Name = "Sam Güvenlik", CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 }
				);
		}
	}
}