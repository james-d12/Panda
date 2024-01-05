using Panda.Core.Common.Enums;

namespace Panda.Core.Modules.Employees.Domain;

public sealed class Employee
{
    public Guid Id { get; }
    public Role Role { get; set; }
    public string Username { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}