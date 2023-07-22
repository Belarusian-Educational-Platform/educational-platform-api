using educational_platform_api.Models;
using educational_platform_api.Repositories;
using educational_platform_api.Services;
using educational_platform_api.Validators;
using FluentValidation;
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
            services.AddTransient<IProfileRepository, ProfileRepository>()
                    .AddTransient<IGroupRepository, GroupRepository>()
                    .AddTransient<ISubgroupRepository, SubgroupRepository>()
                    .AddTransient<IOrganizationRepository, OrganizationRepository>()
                    .AddTransient<IProfileOrganizationRelationRepository, ProfileOrganizationRelationRepository>()
                    .AddTransient<IProfileGroupRelationRepository, ProfileGroupRelationRepository>()
                    .AddTransient<IProfileSubgroupRelationRepository, ProfileSubgroupRelationRepository>()
                    .AddTransient<IGroupOrganizationRelationRepository, GroupOrganizationRelationRepository>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidation()
                .AddScoped<IValidator<Account>, AccountValidator>();

            return services;
        }
    }
}
