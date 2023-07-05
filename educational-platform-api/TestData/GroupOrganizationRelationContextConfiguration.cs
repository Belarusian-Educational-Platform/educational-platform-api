using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class GroupOrganizationRelationContextConfiguration : IEntityTypeConfiguration<GroupOrganizationRelation>
    {
        public void Configure(EntityTypeBuilder<GroupOrganizationRelation> builder)
        {
            
        }
    }
}
