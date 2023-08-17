using educational_platform_api.DTOs.Organization;
using educational_platform_api.ErrorMessages;
using FluentValidation;

namespace educational_platform_api.Validators.Organization
{
    public class CreateOrganizationInputValidator : AbstractValidator<CreateOrganizationInput>
    {
        public CreateOrganizationInputValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Description); // No rules yet

            RuleFor(x => x.Latitude)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .GreaterThanOrEqualTo(-180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue)
                .LessThanOrEqualTo(180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue);

            RuleFor(x => x.Longitude)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .GreaterThanOrEqualTo(-180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue)
                .LessThanOrEqualTo(180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue);

        }
    }
}
