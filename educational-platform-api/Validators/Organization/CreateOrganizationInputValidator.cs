﻿using educational_platform_api.DTOs.Organization;
using FluentValidation;

namespace educational_platform_api.Validators.Organization
{
    public class CreateOrganizationInputValidator : AbstractValidator<CreateOrganizationInput>
    {
        public CreateOrganizationInputValidator()
        {

        }
    }
}