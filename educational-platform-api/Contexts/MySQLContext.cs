using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Contexts
{
    public class MySQLContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Organisation>? Organisations { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Subgroup>? Subgroups { get; set; }
        public DbSet<UserGroupRelation>? UserGroupRelations { get; set; }
        public DbSet<UserSubgroupRelation>? UserSubgroupRelations { get; set; }
        public DbSet<GroupOrganisationRelation>? GroupOrganisationRelations { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Group>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Subgroup>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Organisation>()
               .HasKey(c => new { c.Id });

            modelBuilder.Entity<UserGroupRelation>()
               .HasKey(c => new { c.UserId, c.GroupId });
            modelBuilder.Entity<GroupOrganisationRelation>()
               .HasKey(c => new { c.GroupId, c.OrganisationId });
            modelBuilder.Entity<UserSubgroupRelation>()
               .HasKey(c => new { c.UserId, c.SubgroupId });

        }
    }
}
