﻿using Panda.Core.Common.Abstractions.Messaging;
using Panda.Core.Common.Exceptions;
using Panda.Core.Modules.Employees.Common;

namespace Panda.Core.Modules.Employees.UseCases;

public sealed record GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeResponse>;

internal sealed class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepsitory;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepsitory) => _employeeRepsitory = employeeRepsitory;

    public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepsitory.GetById(query.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Could not find employee with Id {query.Id}");
        }

        return EmployeeMapper.ToResponse(employee);
    }

}