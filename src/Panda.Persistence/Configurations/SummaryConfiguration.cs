using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Summaries.Domain;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class SummaryConfiguration : IEntityTypeConfiguration<Summary>
{
    public void Configure(EntityTypeBuilder<Summary> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).IsRequired().HasColumnOrder(0);
        builder.Property(s => s.BudgetId).IsRequired().HasColumnOrder(1);

        builder.HasIndex(s => s.BudgetId).IsUnique();

        builder
            .HasOne(s => s.Table)
            .WithOne(t => t.Summary)
            .HasForeignKey<Table>(t => t.SummaryId)
            .HasPrincipalKey<Summary>(s => s.Id);
    }
}
