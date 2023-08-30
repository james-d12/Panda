using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;
internal sealed class CellConfiguration : IEntityTypeConfiguration<Cell>
{
    public void Configure(EntityTypeBuilder<Cell> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).IsRequired().HasColumnOrder(0);
        builder.Property(c => c.TableId).IsRequired().HasColumnOrder(1);
        builder.Property(c => c.RowId).IsRequired().HasColumnOrder(2);
        builder.Property(c => c.ColumnId).IsRequired().HasColumnOrder(3);
        builder.Property(c => c.Name).HasColumnOrder(4);
        builder.Property(c => c.Price).HasColumnOrder(5);
        builder.Property(c => c.Quantity).HasColumnOrder(6);
        builder.Property(c => c.DateTime).HasColumnOrder(7);

        builder.HasIndex(c => new { c.RowId, c.ColumnId, c.TableId }).IsUnique();
    }
}