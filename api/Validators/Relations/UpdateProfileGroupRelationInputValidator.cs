using api.DTOs.Relations;
using api.ErrorMessages;
using FluentValidation;
using System.Text.RegularExpressions;

namespace api.Validators.Relations
{
    public class UpdateProfileGroupRelationInputValidator : 
        AbstractValidator<UpdateProfileGroupRelationInput>
    {
        public UpdateProfileGroupRelationInputValidator()
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
                .Must(permissions =>
                {
                    string str = permissions;
                    str = str.Replace("\"", "~");
                    var regexp = @"^[[]([~][]\w|-]+[~]+[,]?)+[]]$";
                    return Regex.Match(str, regexp).Success;
                })
                .WithMessage(CustomErrorMessages.PropertyIncorrectFormat);
        }
    }
}
