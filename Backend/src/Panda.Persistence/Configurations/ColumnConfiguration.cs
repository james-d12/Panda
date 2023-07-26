using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;
internal sealed class ColumnConfiguration : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).IsRequired().HasColumnOrder(0);
        builder.Property(r => r.TableId).IsRequired().HasColumnOrder(1);
        builder.Property(r => r.Title).IsRequired().HasMaxLength(64).HasColumnOrder(2);
        builder.Property(r => r.Field).IsRequired().HasMaxLength(64).HasColumnOrder(3);

        builder.HasIndex(r => r.TableId).IsUnique();

    }
}
