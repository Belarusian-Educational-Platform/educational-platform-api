using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class UserMutation
    {
        [GraphQLName("createUser")]
        public User CreateUser([Service] IUserService userService, User user)
        {
            return user;
        }

        [GraphQLName("updateUser")]
        public User UpdateUser([Service] IUserService userService, User user)
        {
            return user;
        }

        [GraphQLName("deleteUser")]
        public bool DeleteUser([Service] IUserService userService, int id)
        {
            return true;
        }
    }
}
