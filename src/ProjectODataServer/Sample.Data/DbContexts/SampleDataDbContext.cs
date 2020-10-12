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
			modelBuilder.ApplyConfiguration(new OperationMapping());
			modelBuilder.ApplyConfiguration(new TollOperationMapping());
			modelBuilder.ApplyConfiguration(new AccidentOperationMapping());
			modelBuilder.ApplyConfiguration(new TrafficPenaltyOperationMapping());
			modelBuilder.ApplyConfiguration(new TireOperationMapping());
			modelBuilder.ApplyConfiguration(new WinterTireOperationMapping());
		}
	}
}