using ProfileAuthorization;
using ProfileAuthorization.Data;

namespace api.Extensions.Services
{
    public static class ProfileAuthorizationExtension
    {
        public static IServiceCollection AddProfileAuthorization(this IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IVerificationService, VerificationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}
