using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ProjectODataServer;
using Sample.Data.Entities;
using Sample.Data.Mappings;
using System;

namespace Sample.Data.DbContexts
{
	public class SampleDataDbContext : DbContext
	{
		public SampleDataDbContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		public IDateTimeService DateTimeService { get; set; }

		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShoppingCategory> ShoppingCategories { get; set; }
		public DbSet<ServiceCategory> ServiceCategories { get; set; }

		public DbSet<Product> Products { get; set; }
		public DbSet<ShoppingProduct> ShoppingProducts { get; set; }
		public DbSet<ServiceProduct> ServiceProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new VendorMapping());

			modelBuilder.ApplyConfiguration(new CategoryMapping());
			modelBuilder.ApplyConfiguration(new ShoppingCategoryMapping());
			modelBuilder.ApplyConfiguration(new ServiceCategoryMapping());

			modelBuilder.ApplyConfiguration(new ProductMapping());
			modelBuilder.ApplyConfiguration(new ShoppingProductMapping());
			modelBuilder.ApplyConfiguration(new ServiceProductMapping());

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var entries = ChangeTracker.Entries();

			foreach (var entry in entries)
			{
				if (!(entry.Entity is IEntityBase entity)) continue;

				if (entry.State == EntityState.Added)
				{
					entity.CreatedAt = DateTimeService.NowOffset();
					entity.CreatedBy = -1;
					entity.ModifiedAt = DateTimeService.NowOffset();
					entity.ModifiedBy = -1;
				}
				else if (entry.State == EntityState.Modified)
				{
					entry.CurrentValues[nameof(entity.CreatedAt)] = entry.OriginalValues[nameof(entity.CreatedAt)];
					entry.CurrentValues[nameof(entity.CreatedBy)] = entry.OriginalValues[nameof(entity.CreatedBy)];

					entity.ModifiedAt = DateTimeService.NowOffset();
					entity.ModifiedBy = -1;
				}
			}

			return base.SaveChanges(acceptAllChangesOnSuccess);
		}
	}
}