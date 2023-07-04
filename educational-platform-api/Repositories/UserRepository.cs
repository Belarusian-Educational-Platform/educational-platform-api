﻿using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class UserRepository : IUserRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public UserRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public IEnumerable<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }
    }
}
