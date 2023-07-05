using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using educational_platform_api.EnumTypes;

namespace educational_platform_api.TestData
{ 
    public class ProfileGroupRelationContextConfiguration : IEntityTypeConfiguration<ProfileGroupRelation>
    {
        public void Configure(EntityTypeBuilder<ProfileGroupRelation> builder)
        {
            
        }
    }
}
