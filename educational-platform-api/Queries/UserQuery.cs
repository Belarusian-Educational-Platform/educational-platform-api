using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class UserQuery
    {
        [GraphQLName("users")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<User> GetUsers([Service] IUserService userService)
        {
            return userService.GetUsers();
        }

        [GraphQLName("userById")]
        public User GetUser([Service] IUserService userService, int id)
        {
            return new User();
        }
    }
}
