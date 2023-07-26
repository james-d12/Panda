using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).IsRequired().HasColumnOrder(0);
        builder.Property(t => t.SandboxId).HasColumnOrder(1);
        builder.Property(t => t.SummaryId).HasColumnOrder(2);
        builder.Property(t => t.ReviewId).HasColumnOrder(3);

        builder.HasIndex(t => t.SandboxId).IsUnique();
        builder.HasIndex(t => t.SummaryId).IsUnique();
        builder.HasIndex(t => t.ReviewId).IsUnique();

        builder
            .HasMany(t => t.Rows)
            .WithOne(r => r.Table)
            .HasForeignKey(r => r.TableId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(t => t.Columns)
            .WithOne(c => c.Table)
            .HasForeignKey(c => c.TableId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(t => t.Cells)
            .WithOne(c => c.Table)
            .HasForeignKey(c => c.TableId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
