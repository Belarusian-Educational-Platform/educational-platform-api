using ProfileAuthorization;
using ProfileAuthorization.Extensions;

namespace api.Extensions.Services
{
    public static class ProfileAuthorizationExtension
    {
        public static IServiceCollection SetupProfileAuthorization(this IServiceCollection services)
        {
            services.AddProfileAuthorization(options =>
            {
                options.AddPolicy("GetMyOrganization", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "view-private-information").ToPermission()
                        );
                });
                options.AddPolicy("CreateProfile", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "create-profiles").ToPermission()
                    );
                });
                options.AddPolicy("DeleteProfile", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "delete-profiles").ToPermission()
                    );
                });
                options.AddPolicy("GetMyOrganizationProfiles", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "view-private-information")
                            .ToPermission()
                    );
                });
                options.AddPolicy("UpdateOrganization", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "update")
                            .ToPermission()
                    );
                });
                options.AddPolicy("CreateGroup", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "create-groups")
                            .ToPermission()
                    );
                });
                options.AddPolicy("GetMyOrganizationGroups", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "view-private-information")
                            .ToPermission()
                    );
                });
                options.AddPolicy("GetGroupProfiles", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((PermissionLevel.PROFILE_ORGANIZATION, "view-groups-private-information")
                            .ToPermission()) |
                        process((PermissionLevel.PROFILE_GROUP, "view-private-information")
                            .ToPermission())
                    );
                });
                options.AddPolicy("UpdateGroup", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((PermissionLevel.PROFILE_ORGANIZATION, "update-groups")
                            .ToPermission()) |
                        process((PermissionLevel.PROFILE_GROUP, "update")
                            .ToPermission())
                    );
                });
                options.AddPolicy("DeleteGroup", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((PermissionLevel.PROFILE_ORGANIZATION, "delete-groups")
                            .ToPermission()) |
                        process((PermissionLevel.PROFILE_GROUP, "delete")
                            .ToPermission())
                    );
                });
                options.AddPolicy("UpdateProfileGroupRelation", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((PermissionLevel.PROFILE_ORGANIZATION, "edit-group-profiles-permissions")
                            .ToPermission()) |
                        process((PermissionLevel.PROFILE_GROUP, "edit-profiles-permissions")
                            .ToPermission())
                    );
                });
                options.AddPolicy("UpdateProfileOrganizationRelation", policy =>
                {
                    policy.AddRequirements(
                        (PermissionLevel.PROFILE_ORGANIZATION, "edit-profiles-permissions")
                            .ToPermission()
                    );
                });
            });

            return services;
        }

        public static IServiceCollection AddProfileAuthorization(this IServiceCollection services,
            Action<AuthorizationOptions> configure)
        {
            services.Configure(configure);
            services.AddScoped<IPolicyProvider, PolicyProvider>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPolicyVerifier, PolicyVerifier>();
            services.AddScoped<IVerificationOptionsService, 
                VerificationOptionsService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}
