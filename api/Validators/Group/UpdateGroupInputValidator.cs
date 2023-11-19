using api.DTOs.Group;
using api.ErrorMessages;
using api.Extensions.Validators;
using FluentValidation;

namespace api.Validators.Group
{
    public class UpdateGroupInputValidator : AbstractValidator<UpdateGroupInput>
    {
        public UpdateGroupInputValidator() {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage(CustomErrorMessages.PropertyIsNull)
                .NotEmpty()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty);

            RuleFor(x => x.Name)
                .NotEmptyButAllowNull()
                .WithMessage(CustomErrorMessages.PropertyIsEmpty)
                .Length(2, 32)
                .WithMessage(CustomErrorMessages.PropertyIsIncorrectLength);
        }
    }
}
