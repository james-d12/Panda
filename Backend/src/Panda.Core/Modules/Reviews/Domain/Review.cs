using Panda.Core.Common.Enums;
using Panda.Core.Modules.Tables.Domain;
using Panda.Core.Modules.Years.Domain;

namespace Panda.Core.Modules.Reviews.Domain;

public sealed class Review
{
    public Guid Id { get; private set; }
    public Guid YearId { get; private set; }
    public Year Year { get; private set; } = null!;
    public Status Status { get; private set; }
    public Table Table { get; private set; } = null!;

    private Review() { }

    public Review(Guid yearId, Status status)
    {
        Id = Guid.NewGuid();
        YearId = yearId;
        Status = status;
    }

    public void Approve()
    {
        if (Year.Status >= Status.Approved || Status != Status.Reviewed)
        {
            return;
        }

        Status = Status.Approved;
        Year.Approve();
    }
}
