using educational_platform_api.Models;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class UserMutation
    {
        [GraphQLName("createUser")]
        public User CreateUser(User user)
        {
            return user;
        }

        [GraphQLName("updateUser")]
        public User UpdateUser(User user)
        {
            return user;
        }

        [GraphQLName("deleteUser")]
        public bool DeleteUser(int userId)
        {
            return true;
        }
    }
}
