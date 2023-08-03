using educational_platform_api.DTOs.Subgroup;
using educational_platform_api.ErrorMessages;
using FluentValidation;

namespace educational_platform_api.Validators.Subgroup
{
    public class CreateSubgroupInputValidator : AbstractValidator<CreateSubgroupInput>
    {
        public CreateSubgroupInputValidator()
        {

        }
    }
}
