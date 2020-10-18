using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Mappings
{
	public static class EntityTypeBuilderExtensions
	{
		public static void MapEntityFields<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder, string idKeyName = null)
			where TEntity : Entity<TKey>
		{
			builder.HasKey(x => x.Id);

			if (string.IsNullOrWhiteSpace(idKeyName))
			{
				builder.Property(x => x.Id)
					.IsRequired();
			}
			else
			{
				builder.Property(x => x.Id)
					.HasColumnName(idKeyName)
					.IsRequired();
			}

			builder.Property(x => x.CreatedAt)
				.HasDefaultValue(new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.FromHours(3)))
				.IsRequired();

			builder.Property(x => x.CreatedBy)
				.IsRequired();

			builder.Property(x => x.ModifiedAt)
				.HasDefaultValue(new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.FromHours(3)))
				.IsRequired();

			builder.Property(x => x.ModifiedBy)
				.IsRequired();
		}

		public static void MapNameField<TEntity>(this EntityTypeBuilder<TEntity> builder, string columnName = null, bool isRequired = true)
			where TEntity : class
		{
			builder.Property(string.IsNullOrWhiteSpace(columnName) ? "Name" : columnName.Trim())
				.HasMaxLength(32)
				.IsRequired(isRequired);
		}
	}
}