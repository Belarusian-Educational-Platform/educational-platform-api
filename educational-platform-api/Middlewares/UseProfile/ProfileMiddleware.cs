using educational_platform_api.Models;
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

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            Profile profile = new Profile();

            context.ContextData.Add(PROFILE_CONTEXT_DATA_KEY, profile);

            await _next(context);
        }
    }
}
