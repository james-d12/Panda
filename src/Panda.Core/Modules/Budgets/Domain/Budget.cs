using Panda.Core.Common.Enums;
using Panda.Core.Modules.Categories.Domain;
using Panda.Core.Modules.Companies.Domain;
using Panda.Core.Modules.Sandboxes.Domain;
using Panda.Core.Modules.Summaries.Domain;
using Panda.Core.Modules.Years.Domain;

namespace Panda.Core.Modules.Budgets.Domain;

public sealed class Budget
{
    private readonly HashSet<Category> _categories = new();

    private Budget() { }

    public Budget(Guid yearId, Guid companyId, string name, string description, Status status, bool isStandalone,
        BudgetType budgetType)
    {
        Id = Guid.NewGuid();
        YearId = yearId;
        CompanyId = companyId;
        Name = name;
        Description = description;
        Status = status;
        IsStandalone = isStandalone;
        BudgetType = budgetType;
    }

    public Guid Id { get; private set; }
    public Guid YearId { get; private set; }
    public Year Year { get; private set; } = null!;
    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Status Status { get; private set; }
    public bool IsStandalone { get; private set; }
    public BudgetType BudgetType { get; private set; }

    public Sandbox? Sandbox { get; }
    public Summary? Summary { get; }
    public IReadOnlyCollection<Category> Categories => _categories;

    public void Review()
    {
        if (GetReviewalStatus() != ReviewalStatus.CanBeReviewed)
        {
            return;
        }

        Status = Status.Reviewed;
    }

    public void UnReview()
    {
        if (GetReviewalStatus() != ReviewalStatus.CanBeUnReviewed)
        {
            return;
        }

        Status = Status.InProgress;
    }

    public void Approve()
    {
        if (GetApprovalStatus() != ApprovalStatus.CanBeApproved)
        {
            return;
        }

        Status = Status.Approved;
    }

    public void UnApprove()
    {
        if (GetApprovalStatus() != ApprovalStatus.CanBeUnApproved)
        {
            return;
        }

        Status = Status.Reviewed;
    }

    public ReviewalStatus GetReviewalStatus()
    {
        bool isBudgetNotStarted = Status == Status.NotStarted;
        bool isBudgetAlreadyReviewed = Status == Status.Reviewed;
        bool isBudgetAlreadyApproved = Status == Status.Approved;
        bool isEveryCategoryReviewed = Categories.All(category => category.Status == Status.Reviewed);

        if (isBudgetNotStarted)
        {
            return ReviewalStatus.CannotBeReviewed;
        }

        if (isBudgetAlreadyReviewed)
        {
            return ReviewalStatus.CanBeUnReviewed;
        }

        if (isBudgetAlreadyApproved)
        {
            return ReviewalStatus.CannotBeEdited;
        }

        return isEveryCategoryReviewed ? ReviewalStatus.CanBeReviewed : ReviewalStatus.CannotBeReviewed;
    }

    public ApprovalStatus GetApprovalStatus()
    {
        bool isBudgetNotStarted = Status == Status.NotStarted;
        bool isBudgetAlreadyApproved = Status == Status.Approved;
        bool isBudgetAlreadyCompleted = Status == Status.Completed;
        bool isEveryCategoryApproved = Categories.All(category => category.Status == Status.Approved);

        if (isBudgetNotStarted)
        {
            return ApprovalStatus.CannotBeApproved;
        }

        if (isBudgetAlreadyApproved)
        {
            return ApprovalStatus.CanBeUnApproved;
        }

        if (isBudgetAlreadyCompleted)
        {
            return ApprovalStatus.CannotBeEdited;
        }

        return isEveryCategoryApproved ? ApprovalStatus.CanBeApproved : ApprovalStatus.CannotBeApproved;
    }
}