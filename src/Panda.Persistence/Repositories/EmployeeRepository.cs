using Microsoft.EntityFrameworkCore;
using Panda.Core.Modules.Employees;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Persistence.Repositories;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly DbSet<Employee> _dbSet;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Employees;
    }

    public void Add(Employee employee)
    {
        _dbSet.Add(employee);
    }

    public void Update(Employee employee)
    {
        _dbSet.Update(employee);
    }

    public void Delete(Employee employee)
    {
        _dbSet.Remove(employee);
    }

    public Task<List<Employee>> GetAsync(CancellationToken cancellationToken = default)
    {
        return _dbSet.ToListAsync(cancellationToken);
    }

    public Task<Employee?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(employee => employee.Id == id, cancellationToken);
    }

    public Task<Employee?> GetByUnique(string emailAddress, string userName,
        CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(
            employee => employee.EmailAddress == emailAddress || employee.Username == userName, cancellationToken);
    }
}