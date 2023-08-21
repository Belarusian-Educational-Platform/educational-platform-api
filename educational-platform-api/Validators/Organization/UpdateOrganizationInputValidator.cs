using educational_platform_api.DTOs.Organization;
using educational_platform_api.ErrorMessages;
using educational_platform_api.Extensions.Validators;
using FluentValidation;

namespace educational_platform_api.Validators.Organization
{
    public class UpdateOrganizationInputValidator : AbstractValidator<UpdateOrganizationInput>
    {
        public UpdateOrganizationInputValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);

            RuleFor(x => x.Name)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);

            RuleFor(x => x.Description); // No rules yet 

            RuleFor(x => x.Latitude)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .GreaterThanOrEqualTo(-180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue)
                .LessThanOrEqualTo(180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue);

            RuleFor(x => x.Longitude)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .GreaterThanOrEqualTo(-180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue)
                .LessThanOrEqualTo(180)
                .WithMessage(CustomErrorMessages.IncorrectCoordinatesValue);
        }
    }
}
