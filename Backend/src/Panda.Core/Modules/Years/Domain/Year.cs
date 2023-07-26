using Panda.Core.Common.Enums;
using Panda.Core.Modules.Budgets.Domain;

namespace Panda.Core.Modules.Years.Domain;

public sealed class Year
{
    private readonly HashSet<Budget> _budgets = new();
    public Guid Id { get; private set; }
    public Status Status { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateOnly StartDate { get; private set; } = new DateOnly();
    public DateOnly EndDate { get; private set; } = new DateOnly();
    public IReadOnlyCollection<Budget> Budgets { get => _budgets; }

    private Year() { }

    public Year(Status status, string name, string description, DateOnly startDate, DateOnly endDate)
    {
        Id = Guid.NewGuid();
        Status = status;
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void NotStarted()
    {
        if (Status != Status.InProgress)
        {
            return;
        }

        var isAllBudgetsNotStarted = Budgets.All(budget => budget.Status == Status.NotStarted);

        if (!isAllBudgetsNotStarted)
        {
            return;
        }

        Status = Status.NotStarted;
    }

    public void InProgress()
    {
        if (Status != Status.Reviewed || Status != Status.NotStarted)
        {
            return;
        }

        var isAtLeastOneBudgetInProgress = Budgets.Any(budget => budget.Status >= Status.InProgress);

        if (!isAtLeastOneBudgetInProgress)
        {
            return;
        }

        Status = Status.InProgress;
    }

    public void Review()
    {
        if (Status != Status.InProgress)
        {
            return;
        }

        var isAllBudgetsReviewed = Budgets.All(budget => budget.Status >= Status.Reviewed);

        if (!isAllBudgetsReviewed)
        {
            return;
        }

        Status = Status.Reviewed;
    }

    public void Approve()
    {
        if (Status != Status.Reviewed)
        {
            return;
        }

        var isAllBudgetsApproved = Budgets.All(budget => budget.Status >= Status.Approved);

        if (!isAllBudgetsApproved)
        {
            return;
        }

        Status = Status.Approved;
    }

    public void Complete()
    {
        if (Status != Status.Approved)
        {
            return;
        }

        var isAllBudgetsCompleted = Budgets.All(budget => budget.Status >= Status.Completed);

        if (!isAllBudgetsCompleted)
        {
            return;
        }

        Status = Status.Completed;
    }
}
