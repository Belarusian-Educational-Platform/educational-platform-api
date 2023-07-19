using educational_platform_api.Contexts;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Resolvers;

namespace educational_platform_api.Middlewares.UseProfile
{
    public class ProfileMiddleware
    {
        public const string PROFILE_CONTEXT_DATA_KEY = "Profile";

        private readonly FieldDelegate _next;

        public ProfileMiddleware(FieldDelegate next, string policyName)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context, [Service] IProfileService profileService)
        {
            Profile profile = profileService.GetProfileById(1);

            context.ContextData.Add(PROFILE_CONTEXT_DATA_KEY, profile);

            await _next(context);
        }
    }
}
