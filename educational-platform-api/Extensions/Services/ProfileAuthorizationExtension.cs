using educational_platform_api.Extensions.Types;
using educational_platform_api.Middlewares.AuthorizeProfile;
using educational_platform_api.Middlewares.AuthorizeProfile.Policy;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Extensions.Services
{
    public static class ProfileAuthorizationExtension
    {
        public static IServiceCollection SetupProfileAuthorization(this IServiceCollection services)
        {
            services.AddProfileAuthorization(options =>
            {
                options.AddPolicy("edit-group", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "view-private-information").ToPermission()
                    );

                    policy.RequireAssertion(process =>
                        process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "view-private-information").ToPermission())
                    );

                    policy.RequireAssertion(process =>
                        process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "edit-group").ToPermission()) ||
                        process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "edit-group").ToPermission())
                    );
                });
            });

            return services;
        }

        public static IServiceCollection AddProfileAuthorization(this IServiceCollection services,
            Action<ProfileAuthorizationOptions> configure)
        {
            services.Configure(configure);
            services.AddScoped<IProfileAuthorizationPolicyProvider, ProfileAuthorizationPolicyProvider>();
            services.AddScoped<IProfileAuthorizationPolicyVerifier, ProfileAuthorizationPolicyVerifier>();
            services.AddScoped<IProfileAuthorizationService, ProfileAuthorizationService>();

            return services;
        }
    }
}
