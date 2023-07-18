using educational_platform_api.Models;
using educational_platform_api.Types.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class ProfileSubgroupRelationContextConfiguration : IEntityTypeConfiguration<ProfileSubgroupRelation>
    {
        public void Configure(EntityTypeBuilder<ProfileSubgroupRelation> builder)
        {
            builder
                .HasData(
                new ProfileSubgroupRelation
                {
                    SubgroupId = 1,
                    ProfileRole = Role.member,
                    ProfileId = 1,
                    Permissions= "[\"view-private-information\"]"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 1,
                    ProfileRole = Role.administrator,
                    ProfileId = 2,
                    Permissions= "[\"view-private-information\"]"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 1,
                    ProfileRole = Role.owner,
                    ProfileId = 3,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 2,
                    ProfileRole = Role.member,
                    ProfileId = 4,
                    Permissions= "[\"view-private-information\"]"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 2,
                    ProfileRole = Role.owner,
                    ProfileId = 5,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 3,
                    ProfileRole = Role.member,
                    ProfileId = 6,
                    Permissions= "[\"view-private-information\"]"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 3,
                    ProfileRole = Role.owner,
                    ProfileId = 7,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                }
                );
        }
    }
}
