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
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(0, 128)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(3, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Birthday)
                .CanParseDateTime()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactPhone)
                .Matches(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}")//just validation for phone number
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactEmail)
                .EmailAddress()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.Type);// No rules there yet
        }
    }
}
