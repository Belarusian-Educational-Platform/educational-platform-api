using educational_platform_api.ErrorMessages;
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
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull);

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .MaximumLength(32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);


            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .MaximumLength(32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .EmailAddress()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);
        }
    }
}
