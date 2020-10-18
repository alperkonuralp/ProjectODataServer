using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
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



			var datatime = new System.DateTimeOffset(2020, 10, 18, 13, 36, 00, TimeSpan.FromHours(3));
			builder.HasData(
				new { ProductType = 1, Id = 1, Name = "Hamburger", CategoryId = 3, Description = "Hamburger Description", ShortDescription = "Hamburger Short Description", UnitPrice = 15.50, UnitType = ShoppingUnitType.Item, VendorId = 4, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { ProductType = 1, Id = 2, Name = "Potatos", CategoryId = 4, Description = "Potatos Description", ShortDescription = "Potatos Short Description", UnitPrice = 10.00, UnitType = ShoppingUnitType.Kilogram, VendorId = 5, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { ProductType = 1, Id = 3, Name = "SONY 48A9 49'' 121 CM 4K UHD", CategoryId = 5, Description = "SONY 48A9 49'' 121 CM 4K UHD OLED ANDROID SMART TV,DAHİLİ UYDU ALICI Description", ShortDescription = "SONY 48A9 49'' 121 CM 4K UHD OLED ANDROID SMART TV,DAHİLİ UYDU ALICI Short Description", UnitPrice = 15.50, UnitType = ShoppingUnitType.Item, VendorId = 6, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 },
				new { ProductType = 1, Id = 4, Name = "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH", CategoryId = 6, Description = "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH Description", ShortDescription = "LG 24TL510S 24'' 60 CM HD SMART TV,HDMI,USB,DAHİLİ UYDU ALICI,SİYAH Short Description", UnitPrice = 10.00, UnitType = ShoppingUnitType.Kilogram, VendorId = 7, CreatedAt = datatime, CreatedBy = -1, ModifiedAt = datatime, ModifiedBy = -1 }
				);
		}
	}
}