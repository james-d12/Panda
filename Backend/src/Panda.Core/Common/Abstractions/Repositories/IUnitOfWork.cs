﻿namespace Panda.Core.Common.Abstractions.Repositories;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
