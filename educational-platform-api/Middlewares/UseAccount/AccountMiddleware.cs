using educational_platform_api.Models;
using HotChocolate.Resolvers;

namespace educational_platform_api.Middlewares.UseAccount
{
    public class AccountMiddleware
    {
        public const string ACCOUNT_CONTEXT_DATA_KEY = "Account";

        private readonly FieldDelegate _next;

        public AccountMiddleware(FieldDelegate next, string policyName)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            Account account = new Account();

            context.ContextData.Add(ACCOUNT_CONTEXT_DATA_KEY, account);

            await _next(context);
        }
    }
}
