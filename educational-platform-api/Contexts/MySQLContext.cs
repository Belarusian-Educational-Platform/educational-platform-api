using educational_platform_api.Models;
using educational_platform_api.TestData;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Contexts
{
    public class MySQLContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Organization>? Organizations { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Subgroup>? Subgroups { get; set; }
        public DbSet<UserGroupRelation>? UserGroupRelations { get; set; }
        public DbSet<UserSubgroupRelation>? UserSubgroupRelations { get; set; }
        public DbSet<GroupOrganizationRelation>? GroupOrganizationRelations { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserContextConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationContextConfiguration());
            modelBuilder.ApplyConfiguration(new GroupContextConfiguration());
            modelBuilder.ApplyConfiguration(new SubgroupContextConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubgroupRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new GroupOrganizationRelationContextConfiguration());

            modelBuilder.Entity<User>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Group>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Subgroup>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Organization>()
               .HasKey(c => new { c.Id });

            modelBuilder.Entity<UserGroupRelation>()
               .HasKey(c => new { c.UserId, c.GroupId });
            modelBuilder.Entity<GroupOrganizationRelation>()
               .HasKey(c => new { c.GroupId, c.OrganizationId });
            modelBuilder.Entity<UserSubgroupRelation>()
               .HasKey(c => new { c.UserId, c.SubgroupId });


        }
    }
}
