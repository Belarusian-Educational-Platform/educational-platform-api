using educational_platform_api.DTOs;
using educational_platform_api.ErrorMessages;
using FluentValidation;

namespace educational_platform_api.Validators
{
    public class CreateProfileInputValidator : AbstractValidator<CreateProfileInput>
    {
        public CreateProfileInputValidator()
        {
            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage(ProfileErrorMessages.TypeIsNull);

            RuleFor(x => x.ContactPhone)
                .NotNull()
                .WithMessage(ProfileErrorMessages.ContactPhoneIsNull);

            RuleFor(x => x.ContactEmail)
                .NotNull()
                .WithMessage(ProfileErrorMessages.ContactEmailIsNull);
        }
    }
}
