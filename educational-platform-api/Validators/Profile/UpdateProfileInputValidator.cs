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
                .WithMessage(ProfileErrorMessages.KeycloakIdIsNull)
                .NotEmpty()
                .WithMessage(ProfileErrorMessages.KeycloakIdIsEmpty)
                .Length(0, 128)
                .WithMessage(ProfileErrorMessages.KeycloakIdIncorrectLength);

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(ProfileErrorMessages.FirstNameIsNull)
                .NotEmpty()
                .WithMessage(ProfileErrorMessages.FirstNameIsEmpty)
                .Length(3, 32)
                .WithMessage(ProfileErrorMessages.FirstNameIncorrectLength);

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(ProfileErrorMessages.LastNameIsNull)
                .NotEmpty()
                .WithMessage(ProfileErrorMessages.LastNameIsEmpty)
                .Length(3, 32)
                .WithMessage(ProfileErrorMessages.LastNameIncorrectLength);

            RuleFor(x => x.Surname)
                .NotNull()
                .WithMessage(ProfileErrorMessages.SurnameIsNull)
                .NotEmpty()
                .WithMessage(ProfileErrorMessages.SurnameIsEmpty)
                .Length(3, 32)
                .WithMessage(ProfileErrorMessages.SurnameIncorrectLength);

            RuleFor(x => x.Birthday)
                .NotNull()
                .WithMessage(ProfileErrorMessages.BirthdayIsNull)
                .CanParseDateTime()
                .WithMessage(ProfileErrorMessages.BirthdayIncorrectDateFormat);

            RuleFor(x => x.ContactPhone)
                .NotNull()
                .WithMessage(ProfileErrorMessages.ContactPhoneIsNull);

            RuleFor(x => x.ContactEmail)
                .NotNull()
                .WithMessage(ProfileErrorMessages.ContactEmailIsNull);

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage(ProfileErrorMessages.TypeIsNull);
        }
    }
}
