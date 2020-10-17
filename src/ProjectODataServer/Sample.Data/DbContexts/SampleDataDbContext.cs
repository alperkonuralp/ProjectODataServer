using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Sample.Data.Entities;
using Sample.Data.Mappings;

namespace Sample.Data.DbContexts
{
	public class SampleDataDbContext : DbContext
	{
		public SampleDataDbContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		
		public DbSet<Product> Products { get; set; }

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
	}
}