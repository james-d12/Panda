using Panda.Core.Common.Enums;

namespace Panda.Core.Modules.Employees.Common;

public sealed record EmployeeResponse(Guid Id, string EmailAddress, string Username, Role Role);