using educational_platform_api.Models;
using FluentValidation;

namespace educational_platform_api.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.KeycloakId)
                .NotEmpty()
                .WithMessage("UserId empty!")
                .NotNull()
                .WithMessage("UserId wasn`t provided!");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is empty!")
                .NotNull()
                .WithMessage("Username wasn`t provided!");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is empty!")
                .NotNull()
                .WithMessage("First name wasn`t provided!")
                .MaximumLength(32)
                .WithMessage("First name size must be less than 32 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is empty!")
                .NotNull()
                .WithMessage("Last name wasn`t provided!")
                .MaximumLength(32)
                .WithMessage("Last name size must be less than 32 characters!");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Surname is empty!")
                .NotNull()
                .WithMessage("Surname wasn`t provided!")
                .MaximumLength(32)
                .WithMessage("Surname size must be less than 32 characters!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is empty!")
                .NotNull()
                .WithMessage("Email wasn`t provided!")
                .EmailAddress()
                .WithMessage("Email address can`t be recognized!");
        }
    }
}
