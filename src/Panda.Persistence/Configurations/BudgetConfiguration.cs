using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Budgets.Domain;
using Panda.Core.Modules.Sandboxes.Domain;
using Panda.Core.Modules.Summaries.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).IsRequired().HasColumnOrder(0);
        builder.Property(b => b.YearId).IsRequired().HasColumnOrder(1);
        builder.Property(b => b.CompanyId).IsRequired().HasColumnOrder(2);
        builder.Property(b => b.Status).IsRequired().HasConversion<int>().HasColumnOrder(3);
        builder.Property(b => b.BudgetType).IsRequired().HasConversion<int>().HasColumnOrder(4);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(64).HasColumnOrder(5);
        builder.Property(b => b.Description).IsRequired().HasColumnOrder(6);
        builder.Property(b => b.IsStandalone).IsRequired().HasConversion<bool>().HasColumnOrder(7);

        builder.HasIndex(b => b.Name).IsUnique();
        builder.HasIndex(b => new { b.YearId, b.CompanyId }).IsUnique();

        builder
            .HasOne(b => b.Sandbox)
            .WithOne(s => s.Budget)
            .HasForeignKey<Sandbox>(s => s.BudgetId)
            .HasPrincipalKey<Budget>(b => b.Id);

        builder
            .HasOne(b => b.Summary)
            .WithOne(s => s.Budget)
            .HasForeignKey<Summary>(s => s.BudgetId)
            .HasPrincipalKey<Budget>(b => b.Id);
    }
}