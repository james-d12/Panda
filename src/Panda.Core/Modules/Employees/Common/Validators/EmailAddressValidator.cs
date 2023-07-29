using FluentValidation;

namespace Panda.Core.Modules.Employees.Common.Validators;
internal sealed class EmailAddressValidator : AbstractValidator<string>
{
    public EmailAddressValidator()
    {
        RuleFor(x => x)
            .EmailAddress()
            .WithMessage("Email Address must be in a valid format containing an @ symbol.")
            .NotEmpty()
            .WithMessage("Email Address must not be empty.")
            .MaximumLength(100)
            .WithMessage("Email Address cannot be longer than 100 characters.");
    }
}
