using Panda.Core.Modules.Budgets.Domain;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Core.Modules.Transaction.Domain;
public sealed class Transaction
{
    public Guid Id { get; private set; }
    public Guid RowId { get; set; }
    public Row Row { get; private set; } = null!;
    public Guid BudgetId { get; set; }
    public Budget Budget { get; private set; } = null!;
    public Guid SageTransactionId { get; set; }

    private Transaction()
    {

    }

    public Transaction(Guid rowId, Guid budgetId, Guid sageTransactionId)
    {
        Id = Guid.NewGuid();
        RowId = rowId;
        BudgetId = budgetId;
        SageTransactionId = sageTransactionId;
    }
}
