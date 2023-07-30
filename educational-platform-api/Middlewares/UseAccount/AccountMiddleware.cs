using educational_platform_api.Models;
using educational_platform_api.Types;
using educational_platform_api.Validators;
using FluentValidation;
using FluentValidation.Results;
using HotChocolate.Resolvers;
using System.Security.Claims;

namespace educational_platform_api.Middlewares.UseAccount
{
    public class AccountMiddleware
    {
        public const string ACCOUNT_CONTEXT_DATA_KEY = "Account";

        private readonly FieldDelegate _next;

        public AccountMiddleware(FieldDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context, 
            [Service] AccountValidator accountValidator)
        {   
            if(context.ContextData.TryGetValue("ClaimsPrincipal", out object? rawClaimsPrincipal) 
                && rawClaimsPrincipal is ClaimsPrincipal claimsPrincipal)
            {
                Account account = new Account()
                {
                    KeycloakId = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Id),
                    Username = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Username),
                    Email = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Email),
                    FirstName = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.FirstName),
                    LastName = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.LastName)
                };

                ValidationResult validationResult = accountValidator.Validate(account);
                if(!validationResult.IsValid)
                {
                    throw new Exception("Account validation failed!"); // TODO: EXCEPTION NAME
                }

                context.ContextData.Add(ACCOUNT_CONTEXT_DATA_KEY, account);
            } else
            {
                throw new Exception("Something went wrong while accessing token data!"); // TODO: EXCEPTION NAME
            }

            await _next(context);
        }
    }
}
