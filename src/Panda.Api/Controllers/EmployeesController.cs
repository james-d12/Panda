using MediatR;
using Microsoft.AspNetCore.Mvc;
using Panda.Core.Modules.Employees.Common;
using Panda.Core.Modules.Employees.UseCases;

namespace Panda.Api.Controllers;

/// <summary>
///     The employees controller.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public sealed class EmployeesController : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EmployeesController" /> class.
    /// </summary>
    /// <param name="sender"></param>
    public EmployeesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    ///     Gets all of the employees.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The collection of employees.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<EmployeeResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
    {
        GetEmployeesQuery query = new();

        List<EmployeeResponse> employees = await _sender.Send(query, cancellationToken);

        return Ok(employees);
    }

    /// <summary>
    ///     Gets the employee with the specified identifier, if it exists.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The employee with the specified identifier, if it exists.</returns>
    [HttpGet("{employeeId:guid}")]
    [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
    {
        GetEmployeeByIdQuery query = new(employeeId);

        EmployeeResponse employee = await _sender.Send(query, cancellationToken);

        return Ok(employee);
    }

    /// <summary>
    ///     Creates a new employee based on the specified request.
    /// </summary>
    /// <param name="request">The create employee request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The newly created employee.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request,
        CancellationToken cancellationToken)
    {
        CreateEmployeeCommand command = new(Username: request.Username, EmailAddress: request.EmailAddress,
            Role: request.Role);

        EmployeeResponse employee = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetEmployeeById), new { userId = employee.Id }, employee);
    }

    /// <summary>
    ///     Updates the employee with the specified identifier based on the specified request, if it exists.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="request">The update employee request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content.</returns>
    [HttpPut("{employeeId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateEmployee(Guid employeeId, [FromBody] UpdateEmployeeRequest request,
        CancellationToken cancellationToken)
    {
        UpdateEmployeeCommand command = new(employeeId, request.EmailAddress, request.Username, request.Role);

        EmployeeResponse employee = await _sender.Send(command, cancellationToken);

        return Ok(employee);
    }


    /// <summary>
    ///     Deletes the employee with the specified identifier if they exist.
    /// </summary>
    [HttpDelete("{employeeId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEmployee(Guid employeeId, CancellationToken cancellationToken)
    {
        DeleteEmployeeCommand command = new(employeeId);

        bool hasDeleted = await _sender.Send(command, cancellationToken);

        return Ok(hasDeleted);
    }
}