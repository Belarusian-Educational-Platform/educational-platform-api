using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }
    }
}
