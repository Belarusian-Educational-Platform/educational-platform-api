using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class SubgroupContextConfiguration : IEntityTypeConfiguration<Subgroup>
    {
        public void Configure(EntityTypeBuilder<Subgroup> builder)
        {
            
        }
    }
}
