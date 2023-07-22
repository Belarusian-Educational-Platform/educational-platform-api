using educational_platform_api.Models;
using educational_platform_api.Types;
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
        private readonly IValidator<Account> _accountValidator;

        public AccountMiddleware(FieldDelegate next, IValidator<Account> accountValidator)
        {
            _next = next;
            _accountValidator = accountValidator;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {   
            if(context.ContextData.TryGetValue("ClaimsPrincipal", out object rawClaimsPrincipal) 
                && rawClaimsPrincipal is ClaimsPrincipal claimsPrincipal)
            {
                string rawBirthday = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Birthday);
                bool birthdayParseResult = DateOnly.TryParseExact(rawBirthday, "dd/MM/yyyy", out DateOnly birthday);

                Account account = new Account()
                {
                    KeycloakId = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Id),
                    Username = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Username),
                    FirstName = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.FirstName),
                    LastName = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.LastName),
                    Surname = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Surname),
                    Birthday = birthdayParseResult ? birthday : null,
                    Email = claimsPrincipal.FindFirstValue(KeycloakAccountClaimType.Email)
                };

                ValidationResult validationResult = _accountValidator.Validate(account);
                if(!validationResult.IsValid)
                {
                    throw new Exception("Account validation failed!");
                }

                context.ContextData.Add(ACCOUNT_CONTEXT_DATA_KEY, account);
            }

            await _next(context);
        }
    }
}
