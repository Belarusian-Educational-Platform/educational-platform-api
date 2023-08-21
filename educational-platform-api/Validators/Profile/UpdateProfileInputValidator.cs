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
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);

            RuleFor(x => x.KeycloakId)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(0, 128)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.FirstName)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.LastName)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Surname)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Birthday)
                .CanParseDateTimeOrNull()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactPhone)
                .CorrectMobilePhoneFormat()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactEmail)
                .EmailAddress()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.Type); // No rules there yet
        }
    }
}
