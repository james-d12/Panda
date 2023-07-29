using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.BudgetEmployees.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class BudgetEmployeeConfiguration : IEntityTypeConfiguration<BudgetEmployee>
{
    public void Configure(EntityTypeBuilder<BudgetEmployee> builder)
    {
        builder.HasKey(be => be.Id);

        builder.Property(be => be.Id).IsRequired().HasColumnOrder(0);
        builder.Property(be => be.BudgetRole).IsRequired().HasConversion<int>().HasColumnOrder(1);
        builder.Property(be => be.BudgetId).IsRequired().HasColumnOrder(2);
        builder.Property(be => be.EmployeeId).IsRequired().HasColumnOrder(3);

        builder.HasIndex(e => new { e.BudgetId, e.EmployeeId }).IsUnique();
    }
}
