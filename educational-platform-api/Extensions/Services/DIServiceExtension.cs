using educational_platform_api.Repositories;
using educational_platform_api.Services;
using educational_platform_api.Validators;
using educational_platform_api.Validators.Group;
using educational_platform_api.Validators.Organization;
using educational_platform_api.Validators.Profile;
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
                .AddScoped<AccountValidator>()
                .AddScoped<CreateProfileInputValidator>()
                .AddScoped<UpdateProfileInputValidator>()
                .AddScoped<CreateOrganizationInputValidator>()
                .AddScoped<UpdateOrganizationInputValidator>()
                .AddScoped<CreateGroupInputValidator>()
                .AddScoped<UpdateGroupInputValidator>();

            return services;
        }
    }
}
