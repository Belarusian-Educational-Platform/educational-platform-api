using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using educational_platform_api.Models;

namespace educational_platform_api.TestData
{
    public class ProfileContextConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            
        }
    }
}
