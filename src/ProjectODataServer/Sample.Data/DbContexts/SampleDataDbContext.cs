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
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new CategoryMapping());
			modelBuilder.ApplyConfiguration(new ProductMapping());
		}
	}
}