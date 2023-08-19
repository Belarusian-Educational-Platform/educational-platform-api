using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Authorization.ProfileAuthorization.Policy;
using educational_platform_api.Extensions.Types;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Extensions.Services
{
    public static class ProfileAuthorizationExtension
    {
        public static IServiceCollection SetupProfileAuthorization(this IServiceCollection services)
        {
            services.AddProfileAuthorization(options =>
            {
                options.AddPolicy("CreateProfile", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "create-profiles").ToPermission()
                    );
                });
                options.AddPolicy("DeleteProfile", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "delete-profiles").ToPermission()
                    );
                });
                options.AddPolicy("GetMyOrganizationProfiles", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-private-information")
                            .ToPermission()
                    );
                });
                options.AddPolicy("UpdateOrganization", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "update")
                            .ToPermission()
                    );
                });
                options.AddPolicy("CreateGroup", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "create-groups")
                            .ToPermission()
                    );
                });
                options.AddPolicy("GetMyOrganizationGroups", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "veiw-private-information")
                            .ToPermission()
                    );
                });
                options.AddPolicy("GetGroupProfiles", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-groups-private-information")
                            .ToPermission()) |
                        process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "view-private-information")
                            .ToPermission())
                    );
                });
                options.AddPolicy("UpdateGroup", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "update-groups")
                            .ToPermission()) |
                        process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "update")
                            .ToPermission())
                    );
                });
                options.AddPolicy("DeleteGroup", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "delete-groups")
                            .ToPermission()) |
                        process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "delete")
                            .ToPermission())
                    );
                });
                options.AddPolicy("UpdateProfileGroupRelation", policy =>
                {
                    policy.RequireAssertion(process =>
                        process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "edit-group-profiles-permissions")
                            .ToPermission()) |
                        process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "edit-profiles-permissions")
                            .ToPermission())
                    );
                });
                options.AddPolicy("UpdateProfileOrganizationRelation", policy =>
                {
                    policy.AddRequirements(
                        (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "edit-profiles-permissions")
                            .ToPermission()
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
            services.AddScoped<IProfileAuthorizationPermissionService, ProfileAuthorizationPermissionService>();
            services.AddScoped<IProfileAuthorizationPolicyVerifier, ProfileAuthorizationPolicyVerifier>();
            services.AddScoped<IProfileAuthorizationVerificationOptionsService, 
                ProfileAuthorizationVerificationOptionsService>();
            services.AddScoped<IProfileAuthorizationService, ProfileAuthorizationService>();

            return services;
        }
    }
}
