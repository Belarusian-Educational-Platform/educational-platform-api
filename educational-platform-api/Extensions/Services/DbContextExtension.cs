using educational_platform_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Extensions.Services
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
