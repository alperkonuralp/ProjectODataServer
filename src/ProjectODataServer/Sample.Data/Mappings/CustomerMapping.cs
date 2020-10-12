using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class CustomerMapping : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customer");
			builder.HasKey(m => m.Id);

			builder.HasOne(m => m.Account)
				.WithOne(m => m.Customer)
				.HasForeignKey<Customer>(m => m.AccountId)
				.IsRequired();
		}
	}
}