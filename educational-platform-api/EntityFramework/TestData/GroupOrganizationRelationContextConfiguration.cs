using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.EntityFramework.TestData
{
    public class GroupOrganizationRelationContextConfiguration : IEntityTypeConfiguration<GroupOrganizationRelation>
    {
        public void Configure(EntityTypeBuilder<GroupOrganizationRelation> builder)
        {
            builder
                .HasData(
                new GroupOrganizationRelation
                {
                    GroupId = 1,
                    OrganizationId = 1
                },
                new GroupOrganizationRelation
                {
                    GroupId = 2,
                    OrganizationId = 2
                },
                new GroupOrganizationRelation
                {
                    GroupId = 3,
                    OrganizationId = 3
                }
                );
        }
    }
}
