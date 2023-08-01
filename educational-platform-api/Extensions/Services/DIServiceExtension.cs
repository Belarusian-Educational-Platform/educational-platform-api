using educational_platform_api.Repositories;
using educational_platform_api.Services;
using educational_platform_api.Validators;
using educational_platform_api.Validators.Group;
using educational_platform_api.Validators.Organization;
using educational_platform_api.Validators.Profile;
using educational_platform_api.Validators.Relations;
using educational_platform_api.Validators.Subgroup;
using FluentValidation.AspNetCore;

namespace educational_platform_api.Extensions.Services
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>()
                    .AddScoped<IGroupService, GroupService>()
                    .AddScoped<ISubgroupService, SubgroupService>()
                    .AddScoped<IOrganizationService, OrganizationService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<UnitOfWork>();

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
                // Subgroup
                .AddScoped<CreateSubgroupInputValidator>()
                .AddScoped<UpdateSubgroupInputValidator>()
                // Relations
                .AddScoped<CreateProfileGroupRelationInputValidator>()
                .AddScoped<CreateProfileSubgroupRelationInputValidator>();

            return services;
        }
    }
}
