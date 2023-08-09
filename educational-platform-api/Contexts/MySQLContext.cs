using educational_platform_api.Extensions.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Contexts
{
    public class MySQLContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProfileGroupRelation> ProfileGroupRelations { get; set; }
        public DbSet<GroupOrganizationRelation> GroupOrganizationRelations { get; set; }
        public DbSet<ProfileOrganizationRelation> ProfileOrganizationRelations { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyTestData()
                .AddModelsPrimaryKeys()
                .AddModelsRelations();
        }
    }
}
