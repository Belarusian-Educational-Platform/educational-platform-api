using educational_platform_api.Services;
using educational_platform_api.Validators;
using educational_platform_api.Validators.Group;
using educational_platform_api.Validators.Organization;
using educational_platform_api.Validators.Profile;
using educational_platform_api.Validators.Relations;
using FluentValidation.AspNetCore;

namespace educational_platform_api.Extensions.Services
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>()
                    .AddScoped<IGroupService, GroupService>()
                    .AddScoped<IOrganizationService, OrganizationService>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidation()
                //Account
                .AddScoped<AccountValidator>()
                // Profile
                .AddScoped<CreateProfileInputValidator>()
                .AddScoped<UpdateProfileInputValidator>()
                // Organization
                .AddScoped<CreateOrganizationInputValidator>()
                .AddScoped<UpdateOrganizationInputValidator>()
                // Group
                .AddScoped<CreateGroupInputValidator>()
                .AddScoped<UpdateGroupInputValidator>()
                // Relations
                .AddScoped<CreateProfileGroupRelationInputValidator>();

            return services;
        }
    }
}
