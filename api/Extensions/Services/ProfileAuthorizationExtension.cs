using ProfileAuthorization;
using ProfileAuthorization.Data;

namespace api.Extensions.Services
{
    public static class ProfileAuthorizationExtension
    {
        public static IServiceCollection SetupProfileAuthorization(this IServiceCollection services)
        {
            services.AddProfileAuthorization(options =>
            {
                // GROUP_QUERY
                options.AddPolicy(Policies.GET_GROUPS, policy =>
                {
                    policy.AddRequirements(KeycloakPermissions.ADMIN);
                });
                options.AddPolicy(Policies.GET_GROUP_BY_ID, policy => {
                    policy.RequireAssertion(process => 
                        process(OrganizationPermissions.VIEW_PRIVATE_INFORMATION) |
                        process(GroupPermissions.VIEW_PRIVATE_INFORMATION) |
                        process(KeycloakPermissions.ADMIN));
                });
                options.AddPolicy(Policies.GET_MY_ORGANIZATION_GROUPS, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.VIEW_PRIVATE_INFORMATION);
                });

                // PROFILE_QUERY
                options.AddPolicy(Policies.GET_PROFILES, policy =>
                {
                    policy.AddRequirements(KeycloakPermissions.ADMIN);
                });
                options.AddPolicy(Policies.GET_PROFILE_BY_ID, policy => {
                    policy.RequireAssertion(process => 
                        process(OrganizationPermissions.VIEW_PRIVATE_INFORMATION) |
                        process(KeycloakPermissions.ADMIN));
                });



                options.AddPolicy(Policies.GET_MY_ORGANIZATION, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.VIEW_PRIVATE_INFORMATION);
                });
                options.AddPolicy(Policies.CREATE_PROFILE, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.CREATE_PROFILES);
                });
                options.AddPolicy(Policies.DELETE_PROFILE, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.DELETE_GROUPS);
                });
                options.AddPolicy(Policies.GET_MY_ORGANIZATION_PROFILES, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.VIEW_PRIVATE_INFORMATION);
                });
                options.AddPolicy(Policies.UPDATE_ORGANIZATION, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.UPDATE);
                });
                options.AddPolicy(Policies.CREATE_GROUP, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.CREATE_GROUPS);
                });
                
                options.AddPolicy(Policies.GET_GROUP_PROFILES, policy =>
                {
                    policy.RequireAssertion(process =>
                        process(OrganizationPermissions.VIEW_GROUPS_PRIVATE_INFORMATION) |
                        process(GroupPermissions.VIEW_PRIVATE_INFORMATION)
                    );
                });
                options.AddPolicy(Policies.UPDATE_GROUP, policy =>
                {
                    policy.RequireAssertion(process =>
                        process(OrganizationPermissions.UPDATE_GROUPS) | process(GroupPermissions.UPDATE)
                    );
                });
                options.AddPolicy(Policies.DELETE_GROUP, policy =>
                {
                    policy.RequireAssertion(process =>
                        process(OrganizationPermissions.DELETE_GROUPS) |
                        process(GroupPermissions.DELETE)
                    );
                });
                options.AddPolicy(Policies.UPDATE_PROFILE_GROUP_RELATION, policy =>
                {
                    policy.RequireAssertion(process =>
                        process(OrganizationPermissions.EDIT_GROUP_PROFILES_PERMISSIONS) |
                        process(GroupPermissions.EDIT_PROFILES_PERMISSIONS)
                    );
                });
                options.AddPolicy(Policies.UPDATE_PROFILE_ORGANIZATION_RELATION, policy =>
                {
                    policy.AddRequirements(OrganizationPermissions.EDIT_GROUP_PROFILES_PERMISSIONS);
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
