using educational_platform_api.DTOs.Relations;
using educational_platform_api.ErrorMessages;
using FluentValidation;

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
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);
            RuleFor(x => x.Permissions)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);
/*                .Matches(@"^[[]+(?:[\"]+[a - z |\d |\-] +[\"]+[,]?)+[]]$")
                .WithMessage(ProfileErrorMessages.PropertyIncorrectFormat);*/ //TODO create regex

        }
    }
}
