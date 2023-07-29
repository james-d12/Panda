using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;
internal sealed class RowConfiguration : IEntityTypeConfiguration<Row>
{
    public void Configure(EntityTypeBuilder<Row> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).IsRequired().HasColumnOrder(0);
        builder.Property(r => r.TableId).IsRequired().HasColumnOrder(1);
        builder.Property(r => r.Notes).IsRequired().HasMaxLength(256).HasColumnOrder(2);

        builder.HasIndex(r => r.TableId).IsUnique();
    }
}
