using Panda.Core.Common.Abstractions.Messaging;
using Panda.Core.Modules.Employees.Common;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Core.Modules.Employees.UseCases;

public sealed record GetEmployeesQuery : IQuery<List<EmployeeResponse>>;

internal sealed class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, List<EmployeeResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeesQueryHandler(IEmployeeRepository userRepository)
    {
        _employeeRepository = userRepository;
    }

    public async Task<List<EmployeeResponse>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        List<Employee> employees = await _employeeRepository.GetAsync(cancellationToken);
        return EmployeeMapper.ToResponseList(employees);
    }
}