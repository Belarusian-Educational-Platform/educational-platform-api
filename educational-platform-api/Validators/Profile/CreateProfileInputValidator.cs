using educational_platform_api.DTOs.Profile;
using educational_platform_api.ErrorMessages;
using educational_platform_api.Extensions.Validators;
using FluentValidation;

namespace educational_platform_api.Validators.Profile
{
    public class CreateProfileInputValidator : AbstractValidator<CreateProfileInput>
    {
        public CreateProfileInputValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Surname)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);


            RuleFor(x => x.Birthday)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .CanParseDateTime()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactPhone)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .CorrectMobilePhoneFormat()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);

            RuleFor(x => x.ContactEmail)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull);

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull);
        }
    }
}
