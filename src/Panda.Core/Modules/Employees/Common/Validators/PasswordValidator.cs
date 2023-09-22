using FluentValidation;

namespace Panda.Core.Modules.Employees.Common.Validators;

internal sealed class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Password must not be empty.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(64)
            .WithMessage("Password cannot be longer than 64 characters.");
    }
}