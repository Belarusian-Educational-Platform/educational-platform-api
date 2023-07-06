using HotChocolate.Resolvers;

namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class AuthorizeProfileMiddleware
    {
        private readonly FieldDelegate _next;

        public AuthorizeProfileMiddleware(FieldDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {


            await _next(context);
        }
    }
}
