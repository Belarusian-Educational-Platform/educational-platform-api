using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class SubgroupContextConfiguration : IEntityTypeConfiguration<Subgroup>
    {
        public void Configure(EntityTypeBuilder<Subgroup> builder)
        {
            builder.HasData(
                new Subgroup
                {
                    Id= 1,
                    Name= "Blueberry Pies",
                    GroupId=1,
                },
                new Subgroup
                {
                    Id = 2,
                    Name = "Firefly Sparks",
                    GroupId = 2,
                },
                new Subgroup
                {
                    Id = 3,
                    Name = "Thunderbolt Strikes\r\n",
                    GroupId = 3,
                }
            );
        }
    }
}
