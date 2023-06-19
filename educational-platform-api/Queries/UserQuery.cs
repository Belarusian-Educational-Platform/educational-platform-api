using educational_platform_api.Exceptions;
using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class UserQuery
    {
        private readonly IUserService userService;

        public UserQuery(IUserService userService)
        {
            this.userService = userService;
        }

        [GraphQLName("users")]
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();

            throw new UserException(
                "Something went wrong while getting users!", 
                ExceptionSource.USER
            );

            return users;
        }

        [GraphQLName("userById")]
        public User GetUser(int userId)
        {
            return new User();
        }
    }
}
