using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class UserGroupRelationContextConfiguration : IEntityTypeConfiguration<UserGroupRelation>
    {
        public void Configure(EntityTypeBuilder<UserGroupRelation> builder)
        {
            builder
                .HasData(
                new UserGroupRelation {
                    GroupId = 1,
                    Role = "Student",
                    UserId= 1,
                    },
                new UserGroupRelation
                {
                    GroupId = 1,
                    Role = "Student",
                    UserId = 2,
                },
                new UserGroupRelation
                {
                    GroupId = 1,
                    Role = "Student",
                    UserId = 3,
                },
                new UserGroupRelation
                {
                    GroupId = 2,
                    Role = "Student",
                    UserId = 4,
                },
                new UserGroupRelation
                {
                    GroupId = 2,
                    Role = "Student",
                    UserId = 5,
                },
                new UserGroupRelation
                {
                    GroupId = 3,
                    Role = "Student",
                    UserId = 6,
                },
                new UserGroupRelation
                {
                    GroupId = 3,
                    Role = "Student",
                    UserId = 7,
                }
                );
        }
    }
}
