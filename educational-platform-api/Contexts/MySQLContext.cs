using educational_platform_api.Models;
using educational_platform_api.TestData;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

            modelBuilder.ApplyConfiguration(new ProfileContextConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationContextConfiguration());
            modelBuilder.ApplyConfiguration(new GroupContextConfiguration());
            modelBuilder.ApplyConfiguration(new SubgroupContextConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileGroupRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileSubgroupRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new GroupOrganizationRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new AccountContextConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileOrganizationRelationContextConfiguration());

            modelBuilder.Entity<Profile>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Group>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Subgroup>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Organization>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Account>()
                .HasKey(c => new { c.Id });


            modelBuilder.Entity<ProfileGroupRelation>()
               .HasKey(c => new { c.ProfileId, c.GroupId });
            modelBuilder.Entity<GroupOrganizationRelation>()
               .HasKey(c => new { c.GroupId, c.OrganizationId });
            modelBuilder.Entity<ProfileSubgroupRelation>()
               .HasKey(c => new { c.ProfileId, c.SubgroupId });
            modelBuilder.Entity<ProfileOrganizationRelation>()
                .HasKey(c => new { c.ProfileId, c.OrganizationId });


        }
    }
}
