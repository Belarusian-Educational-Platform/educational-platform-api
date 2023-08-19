using educational_platform_api.DTOs.Relations;
using educational_platform_api.ErrorMessages;
using educational_platform_api.Extensions.Validators;
using FluentValidation;
using System.Text.RegularExpressions;

namespace educational_platform_api.Validators.Relations
{
    public class CreateProfileGroupRelationInputValidator : AbstractValidator<CreateProfileGroupRelationInput>
    {
        public CreateProfileGroupRelationInputValidator()
        {
            RuleFor(x => x.ProfileId)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);
            RuleFor(x => x.GroupId)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);
            RuleFor(x => x.ProfileRole)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull);
            RuleFor(x => x.Permissions)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
         //       .CorrectPermissionsFormat()
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);
        }
    }
}
