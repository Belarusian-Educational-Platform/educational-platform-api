using api.Models;
using api.Services;
using api.Types;
using HotChocolate.Resolvers;
using System.Security.Claims;

namespace api.Middlewares.UseProfile
{
    public class ProfileMiddleware
    {
        public const string PROFILE_CONTEXT_DATA_KEY = "Profile";

        private readonly FieldDelegate _next;

        public ProfileMiddleware(FieldDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context, [Service] IProfileService profileService)
        {
            if (context.ContextData.TryGetValue("ClaimsPrincipal", out object? rawClaimsPrincipal)
                && rawClaimsPrincipal is ClaimsPrincipal claimsPrincipal)
            {
                if (!context.ContextData.ContainsKey(PROFILE_CONTEXT_DATA_KEY))
                {
                    string? keycloakId = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Id);
                    if (keycloakId is null || keycloakId.Length == 0)
                    {
                        throw new UnauthorizedAccessException();
                    }

                    Profile profile = profileService.GetByAccount(keycloakId).First();

                    context.ContextData.TryAdd(PROFILE_CONTEXT_DATA_KEY, profile);
                }
            } else
            {
                throw new UnauthorizedAccessException();
            }

            await _next(context);
        }
    }
}
