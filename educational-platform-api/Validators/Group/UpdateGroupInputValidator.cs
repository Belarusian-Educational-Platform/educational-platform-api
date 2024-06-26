﻿using educational_platform_api.DTOs.Group;
using educational_platform_api.ErrorMessages;
using educational_platform_api.Extensions.Validators;
using FluentValidation;

namespace educational_platform_api.Validators.Group
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
