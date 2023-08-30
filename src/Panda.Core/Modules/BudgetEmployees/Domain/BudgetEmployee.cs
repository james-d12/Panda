using Panda.Core.Common.Enums;

namespace Panda.Core.Modules.BudgetEmployees.Domain;

public sealed class BudgetEmployee
{
    public Guid Id { get; private set; }
    public Guid BudgetId { get; private set; }
    public Guid EmployeeId { get; private set; }
    public BudgetRole BudgetRole { get; private set; }

    private BudgetEmployee() { }

    public BudgetEmployee(Guid budgetId, Guid employeeId, BudgetRole budgetRole)
    {
        Id = Guid.NewGuid();
        BudgetId = budgetId;
        EmployeeId = employeeId;
        BudgetRole = budgetRole;
    }

}