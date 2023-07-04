﻿using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
    }
}
