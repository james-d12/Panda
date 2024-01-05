using FluentValidation;

namespace Panda.Core.Modules.Employees.Common.Validators;

internal sealed class UsernameValidator : AbstractValidator<string>
{
    public UsernameValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Username must not be empty.")
            .MinimumLength(8)
            .WithMessage("Username must be at least 8 characters.")
            .MaximumLength(64)
            .WithMessage("Username must not be more than 64 characters.");
    }
}