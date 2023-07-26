using Panda.Core.Modules.Budgets.Domain;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Core.Modules.Summaries.Domain;

public sealed class Summary
{
    public Guid Id { get; private set; }
    public Guid BudgetId { get; private set; }
    public Budget Budget { get; private set; } = null!;
    public Table Table { get; private set; } = null!;

    private Summary() { }

    public Summary(Guid budgetId)
    {
        Id = Guid.NewGuid();
        BudgetId = budgetId;
    }
}
