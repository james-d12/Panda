using Panda.Core.Common.Abstractions.Messaging;
using Panda.Core.Common.Abstractions.Repositories;
using Panda.Core.Common.Exceptions;

namespace Panda.Core.Modules.Employees.UseCases;

public sealed record DeleteEmployeeCommand(Guid Id) : ICommand<bool>;

internal sealed class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetById(command.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Could not find employee with Id {command.Id}");
        }

        _employeeRepository.Delete(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

}