using educational_platform_api.Models;
using educational_platform_api.TestData;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Contexts
{
    public class MySQLContext : DbContext
    {
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Profile>? Profiles { get; set; }
        public DbSet<Organization>? Organizations { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Subgroup>? Subgroups { get; set; }
        public DbSet<ProfileGroupRelation>? ProfileGroupRelations { get; set; }
        public DbSet<ProfileSubgroupRelation>? ProfileSubgroupRelations { get; set; }
        public DbSet<GroupOrganizationRelation>? GroupOrganizationRelations { get; set; }
        public DbSet<ProfileOrganizationRelation>? ProfileOrganizationRelations { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyContextConfiguration()
                .AddModelPrimaryKeys();
        }
    }
}
