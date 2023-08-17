using educational_platform_api.DTOs.Group;
using educational_platform_api.ErrorMessages;
using FluentValidation;

namespace educational_platform_api.Validators.Group
{
    public class CreateGroupInputValidator : AbstractValidator<CreateGroupInput>
    {
        public CreateGroupInputValidator() {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.OrganizationId)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);
        }
    }
}
