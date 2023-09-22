using Panda.Core.Modules.Employees.Common;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Core.Modules.Employees;

internal static class EmployeeMapper
{
    public static EmployeeResponse ToResponse(Employee employee)
    {
        return new EmployeeResponse(employee.Id, employee.EmailAddress, employee.Username, employee.Role);
    }

    public static List<EmployeeResponse> ToResponseList(IEnumerable<Employee> employees)
    {
        return employees.Select(ToResponse).ToList();
    }
}