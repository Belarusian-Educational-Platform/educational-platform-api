using api.Exceptions.BusinessLogicExceptions;
using api.Models;
using api.Types;
using api.Validators;
using FluentValidation.Results;
using HotChocolate.Resolvers;
using System.Security.Claims;

namespace api.Middlewares.UseAccount
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
                    throw new EntityValidationException(nameof(Account));
                }

                context.ContextData.Add(ACCOUNT_CONTEXT_DATA_KEY, account);
            } else
            {
                throw new UnauthorizedAccessException();
            }

            await _next(context);
        }
    }
}
