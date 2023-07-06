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
    }
}
