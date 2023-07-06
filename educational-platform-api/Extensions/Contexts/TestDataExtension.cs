using educational_platform_api.TestData;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Extensions.Contexts
{
    public static class TestDataExtension
    {
        public static ModelBuilder ApplyTestData(this ModelBuilder modelBuilder)
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
        }d
    }
}
