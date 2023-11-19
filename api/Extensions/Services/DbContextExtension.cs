using api.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions.Services
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, 
            string dbConnectionString)
        {
            services.AddPooledDbContextFactory<MySQLContext>(options => {
                 var connectionString = dbConnectionString;
                 options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
             });

            return services;
        }
    }
}
