using Panda.Core.Common.Abstractions.Messaging;
using Panda.Core.Common.Exceptions;
using Panda.Core.Modules.Employees.Common;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Core.Modules.Employees.UseCases;

public sealed record GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeResponse>;

internal sealed class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
    {
        Employee? employee = await _employeeRepository.GetById(query.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Could not find employee with Id {query.Id}");
        }

        return EmployeeMapper.ToResponse(employee);
    }
}