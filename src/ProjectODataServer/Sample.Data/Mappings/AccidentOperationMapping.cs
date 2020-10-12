using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;

namespace Sample.Data.Mappings
{
	public class AccidentOperationMapping : IEntityTypeConfiguration<AccidentOperation>
	{
		public void Configure(EntityTypeBuilder<AccidentOperation> builder)
		{
			builder.Property(m => m.Type)
				.HasColumnName("Type")
				.HasMaxLength(32)
				.IsRequired();
		}
	}
}