using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class UserSubgroupRelationContextConfiguration : IEntityTypeConfiguration<UserSubgroupRelation>
    {
        public void Configure(EntityTypeBuilder<UserSubgroupRelation> builder)
        {
            builder
                .HasData(
                    new UserSubgroupRelation
                    {
                        SubgroupId  = 1,
                        Role = 13,
                        UserId = 1,
                    },
                new UserSubgroupRelation
                {
                    SubgroupId = 1,
                    Role = 13,
                    UserId = 2,
                },
                new UserSubgroupRelation
                {
                    SubgroupId = 1,
                    Role = 13,
                    UserId = 3,
                },
                new UserSubgroupRelation
                {
                    SubgroupId = 2,
                    Role = 13,
                    UserId = 4,
                },
                new UserSubgroupRelation
                {
                    SubgroupId = 2,
                    Role = 13,
                    UserId = 5,
                },
                new UserSubgroupRelation
                {
                    SubgroupId = 3,
                    Role = 13,
                    UserId = 6,
                },
                new UserSubgroupRelation
                {
                    SubgroupId = 3,
                    Role = 13,
                    UserId = 7,
                }
                );
        }
    }
}
