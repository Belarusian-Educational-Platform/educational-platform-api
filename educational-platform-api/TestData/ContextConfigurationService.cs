using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.TestData
{
    public static class ContextConfigurationService
    {
        public static ModelBuilder ApplyContextConfiguration(this ModelBuilder modelBuilder)
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

            return modelBuilder;
        }

        public static ModelBuilder AddModelPrimaryKeys(this ModelBuilder modelBuilder)
        {
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

            return modelBuilder;
        }
    }
}
