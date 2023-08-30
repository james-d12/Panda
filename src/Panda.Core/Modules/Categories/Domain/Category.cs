using Panda.Core.Common.Enums;
using Panda.Core.Modules.Budgets.Domain;
using Panda.Core.Modules.Sages.Domain;

namespace Panda.Core.Modules.Categories.Domain;

public sealed class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Guid BudgetId { get; private set; }
    public Budget Budget { get; private set; } = null!;
    public Status Status { get; private set; }
    public CategoryType CategoryType { get; private set; }
    public CategoryField CategoryField { get; private set; }
    public List<Sage> Sages { get; private set; } = new();

    private Category() { }

    public Category(string name, Guid budgetId, CategoryType categoryType, CategoryField categoryField)
    {
        Id = Guid.NewGuid();
        Name = name;
        BudgetId = budgetId;
        Status = Status.NotStarted;
        CategoryType = categoryType;
        CategoryField = categoryField;
    }

    public void SetNotStarted()
    {
        if (Status == Status.Completed || Status == Status.Approved || Status == Status.Reviewed) return;
        Status = Status.NotStarted;
    }

    public void SetInProgress()
    {
        if (Status == Status.Completed || Status == Status.Approved || Status == Status.Reviewed) return;
        Status = Status.InProgress;
    }

    public void SetReviewed()
    {
        if (Status != Status.InProgress && Status != Status.Approved) return;
        Status = Status.Reviewed;
    }

    public void SetApproved()
    {
        if (Status != Status.Completed && Status != Status.Reviewed) return;
        Status = Status.Approved;
    }
}