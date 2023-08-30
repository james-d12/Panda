using FluentValidation;
using Panda.Core.Common.Abstractions.Messaging;
using Panda.Core.Common.Abstractions.Repositories;
using Panda.Core.Common.Enums;
using Panda.Core.Common.Exceptions;
using Panda.Core.Modules.Employees.Common;
using Panda.Core.Modules.Employees.Common.Validators;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Core.Modules.Employees.UseCases;
public sealed record CreateEmployeeRequest(string EmailAddress, string Username, Role Role);

public sealed record CreateEmployeeCommand(string EmailAddress, string Username, Role Role) : ICommand<EmployeeResponse>;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmailAddress).SetValidator(new EmailAddressValidator());
        RuleFor(x => x.Username).SetValidator(new UsernameValidator());
        RuleFor(x => x.Role)
            .IsInEnum()
            .WithMessage("Role must be an ID of a valid Role Option.");
    }
}

internal sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EmployeeResponse> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {

        var employeeExists = await _employeeRepository.GetByUnique(emailAddress: command.EmailAddress, userName: command.Username, cancellationToken);

        if (employeeExists is not null)
        {
            throw new ConflictException($"Could not create new employee, as employee exists with Username / Email Address.");
        }

        var employee = new Employee
        {
            Role = command.Role,
            EmailAddress = command.EmailAddress,
            Username = command.Username
        };

        _employeeRepository.Add(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return EmployeeMapper.ToResponse(employee);
    }

}