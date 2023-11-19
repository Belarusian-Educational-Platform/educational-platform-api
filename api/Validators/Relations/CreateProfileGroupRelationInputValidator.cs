using api.DTOs.Relations;
using api.ErrorMessages;
using api.Extensions.Validators;
using FluentValidation;
using System.Text.RegularExpressions;

namespace api.Validators.Relations
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
