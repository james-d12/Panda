using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Transaction.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).IsRequired().HasColumnOrder(0);
        builder.Property(t => t.RowId).IsRequired().HasColumnOrder(1);
        builder.Property(t => t.BudgetId).IsRequired().HasColumnOrder(2);
        builder.Property(t => t.SageTransactionId).IsRequired().HasColumnOrder(3);

        builder.HasIndex(t => new { t.RowId, t.BudgetId, t.SageTransactionId }).IsUnique();
    }
}