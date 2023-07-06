using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Mutations
{
    public class AccountMutation
    {
        [GraphQLName("createAccount")]
        public Account CreateAccount([Service] IAccountService accountService, Account account)
        {
            return account;
        }

        [GraphQLName("updateAccount")]
        public Account UpdateAccount([Service] IAccountService accountService, Account account)
        {
            return account;
        }

        [GraphQLName("deleteAccount")]
        public bool DeleteAccount([Service] IAccountService accountService, int id)
        {
            return true;
        }
    }
}
