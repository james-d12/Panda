using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Sandboxes.Domain;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class SandboxConfiguration : IEntityTypeConfiguration<Sandbox>
{
    public void Configure(EntityTypeBuilder<Sandbox> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).IsRequired().HasColumnOrder(0);
        builder.Property(s => s.BudgetId).IsRequired().HasColumnOrder(1);

        builder.HasIndex(s => s.BudgetId).IsUnique();

        builder
            .HasOne(s => s.Table)
            .WithOne(t => t.Sandbox)
            .HasForeignKey<Table>(t => t.SandboxId)
            .HasPrincipalKey<Sandbox>(s => s.Id);
    }
}
