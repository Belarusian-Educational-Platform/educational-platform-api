using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class AccountQuery
    {
        [GraphQLName("account")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public List<Account> GetAccounts([Service] IAccountService accountService)
        {
            return new List<Account>();
        }

        [GraphQLName("accountById")]
        public Account GetAccount([Service] IAccountService accountService, int id)
        {
            return new Account();
        }
    }
}
