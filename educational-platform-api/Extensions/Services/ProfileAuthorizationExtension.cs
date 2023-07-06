using educational_platform_api.Middlewares.AuthorizeProfile;

namespace educational_platform_api.Extensions.Services
{
    public static class ProfileAuthorizationExtension
    {
        public static IServiceCollection AddProfileAuthorization(this IServiceCollection services, 
            Action<ProfileAuthorizationOptions> configure)
        {
            return services;
        }
    }
}
