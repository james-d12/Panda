using Panda.Core.Domain.Repositories;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Core.Modules.Employees;
public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetByUnique(string emailAddress, string userName, CancellationToken cancellationToken);
}
