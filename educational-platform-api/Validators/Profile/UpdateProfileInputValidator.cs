using educational_platform_api.DTOs.Profile;
using educational_platform_api.ErrorMessages;
using educational_platform_api.Extensions.Validators;
using FluentValidation;

namespace educational_platform_api.Validators.Profile
{
    public class UpdateProfileInputValidator : AbstractValidator<UpdateProfileInput>
    {
        public UpdateProfileInputValidator()
        {
            RuleFor(x => x.KeycloakId)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(0, 128)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Surname)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Birthday)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .CanParseDateTime()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactPhone)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .Matches(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}")//just validation for phone number
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactEmail)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .EmailAddress()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull);
        }
    }
}
