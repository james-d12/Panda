using Panda.Core.Common.Abstractions.Repositories;

namespace Panda.Persistence.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _dbContext;

    public UnitOfWork(ApplicationDBContext dbContext) => _dbContext = dbContext;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);

}