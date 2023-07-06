using educational_platform_api.Repositories;
using educational_platform_api.Services;

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
                    .AddTransient<IOrganizationRepository, OrganizationRepository>();

            return services;
        }
    }
}
