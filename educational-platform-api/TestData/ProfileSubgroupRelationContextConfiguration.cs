using educational_platform_api.EnumTypes;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class ProfileSubgroupRelationContextConfiguration : IEntityTypeConfiguration<ProfileSubgroupRelation>
    {
        public void Configure(EntityTypeBuilder<ProfileSubgroupRelation> builder)
        {
        }
    }
}
