using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class AccountMapping : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.ToTable("Account");
			builder.HasDiscriminator<string>("AccountType")
				.HasValue<Person>(nameof(Person))
				.HasValue<Company>(nameof(Company))
				.HasValue<Employee>(nameof(Employee))
				.HasValue<Supplier>(nameof(Supplier))
				;


			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("Id")
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(32)
				.IsRequired();

			builder.Property(x => x.CreatedAt).IsRequired();
			builder.Property(x => x.CreatedBy).IsRequired();
			builder.Property(x => x.ModifiedAt);
			builder.Property(x => x.ModifiedBy);

		}
	}
}