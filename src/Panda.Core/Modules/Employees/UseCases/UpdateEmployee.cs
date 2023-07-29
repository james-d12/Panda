using FluentValidation;
using Panda.Core.Common.Abstractions.Messaging;
using Panda.Core.Common.Abstractions.Repositories;
using Panda.Core.Common.Enums;
using Panda.Core.Common.Exceptions;
using Panda.Core.Modules.Employees.Common;
using Panda.Core.Modules.Employees.Common.Validators;

namespace Panda.Core.Modules.Employees.UseCases;

public sealed record UpdateEmployeeRequest(string EmailAddress, string Username, Role Role);

public sealed record UpdateEmployeeCommand(Guid Id, string EmailAddress, string Username, Role Role) : ICommand<EmployeeResponse>;

public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.EmailAddress).SetValidator(new EmailAddressValidator());
        RuleFor(x => x.Username).SetValidator(new UsernameValidator());
        RuleFor(x => x.Role)
            .IsInEnum()
            .WithMessage("Role must be an ID of a valid Role Option.");
    }

}

internal sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetById(Id: request.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Could not find Employee with Id: ${request.Id}.");
        }

        employee.Role = request.Role;
        employee.Username = request.Username;
        employee.EmailAddress = request.EmailAddress;

        _employeeRepository.Update(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return EmployeeMapper.ToResponse(employee);
    }
}