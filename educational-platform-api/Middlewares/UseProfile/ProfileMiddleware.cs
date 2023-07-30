using educational_platform_api.Contexts;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Types;
using HotChocolate.Resolvers;
using System.Security.Claims;

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
            if (context.ContextData.TryGetValue("ClaimsPrincipal", out object? rawClaimsPrincipal)
                && rawClaimsPrincipal is ClaimsPrincipal claimsPrincipal)
            {
                if (!context.ContextData.ContainsKey(PROFILE_CONTEXT_DATA_KEY))
                {
                    string? keycloakId = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Id);
                    if (keycloakId is null || keycloakId.Length == 0)
                    {
                        throw new Exception("Keycloak Id wasn`t found!"); // TODO: EXCEPTION NAME
                    }

                    Profile profile = profileService.GetActiveProfile(keycloakId);

                    context.ContextData.TryAdd(PROFILE_CONTEXT_DATA_KEY, profile);
                }
            }

            await _next(context);
        }
    }
}
