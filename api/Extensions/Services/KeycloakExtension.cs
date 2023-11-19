using Keycloak.AuthServices.Authentication;

namespace api.Extensions.Services
{
    public static class KeycloakExtension
    {
        public static IServiceCollection SetupKeycloak(this IServiceCollection services, 
            KeycloakAuthenticationOptions authenticationOptions)
        {
            services.AddKeycloakAuthentication(authenticationOptions, options =>
            {
                options.RequireHttpsMetadata = false;
            });

            return services;
        }
    }
}
