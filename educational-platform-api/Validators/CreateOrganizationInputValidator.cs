﻿using educational_platform_api.DTOs;
using FluentValidation;

namespace educational_platform_api.Validators
{
    public class CreateOrganizationInputValidator : AbstractValidator<CreateOrganizationInput>
    {
        public CreateOrganizationInputValidator()
        {
            
        }
    }
}