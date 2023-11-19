namespace api.Middlewares.UseAccount
{
    public class AccountAttribute : GlobalStateAttribute
    {
        public AccountAttribute() : base(AccountMiddleware.ACCOUNT_CONTEXT_DATA_KEY) { }
    }
}
