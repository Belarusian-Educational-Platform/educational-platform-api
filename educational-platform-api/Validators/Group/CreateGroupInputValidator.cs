using educational_platform_api.DTOs.Group;
using FluentValidation;

namespace educational_platform_api.Validators.Group
{
    public class CreateGroupInputValidator : AbstractValidator<CreateGroupInput>
    {
        public CreateGroupInputValidator() { }
    }
}
