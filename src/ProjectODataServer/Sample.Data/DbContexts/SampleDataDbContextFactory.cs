using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sample.Data.DbContexts
{
	public class SampleDataDbContextFactory : IDesignTimeDbContextFactory<SampleDataDbContext>
	{
		public SampleDataDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<SampleDataDbContext>();
			optionsBuilder.UseSqlite("Data Source=SampleData.db");

			return new SampleDataDbContext(optionsBuilder.Options);
		}
	}
}