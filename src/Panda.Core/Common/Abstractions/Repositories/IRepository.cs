namespace Panda.Core.Common.Abstractions.Repositories;

public interface IRepository<T> where T : class
{
    void Add(T employee);
    void Update(T employee);
    void Delete(T employee);
    Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
    Task<T?> GetById(Guid id, CancellationToken cancellationToken = default);
}