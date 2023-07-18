using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.TestData
{
    public class ProfileGroupRelationContextConfiguration : IEntityTypeConfiguration<ProfileGroupRelation>
    {
        public void Configure(EntityTypeBuilder<ProfileGroupRelation> builder)
        {
            builder
                .HasData(
                new ProfileGroupRelation
                {
                    GroupId = 1,
                    ProfileRole = Role.member,
                    ProfileId = 1,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileGroupRelation
                {
                    GroupId = 1,
                    ProfileRole = Role.administrator,
                    ProfileId = 2,
                    Permissions = "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileGroupRelation
                {
                    GroupId = 1,
                    ProfileRole = Role.owner,
                    ProfileId = 3,
                    Permissions = "{\"Permissions\":[\"update\",\"view-private-information\"]}"
                },
                new ProfileGroupRelation
                {
                    GroupId = 2,
                    ProfileRole = Role.member,
                    ProfileId = 4,
                    Permissions = "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileGroupRelation
                {
                    GroupId = 2,
                    ProfileRole = Role.owner,
                    ProfileId = 5,
                    Permissions = "{\"Permissions\":[\"update\",\"view-private-information\"]}"
                },
                new ProfileGroupRelation
                {
                    GroupId = 3,
                    ProfileRole = Role.member,
                    ProfileId = 6,
                    Permissions = "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileGroupRelation
                {
                    GroupId = 3,
                    ProfileRole = Role.owner,
                    ProfileId = 7,
                    Permissions = "{\"Permissions\":[\"update\",\"view-private-information\"]}"
                }
                );
        }
    }
}
