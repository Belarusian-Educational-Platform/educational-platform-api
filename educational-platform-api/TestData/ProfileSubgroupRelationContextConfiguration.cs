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
            builder
                .HasData(
                new ProfileSubgroupRelation
                {
                    SubgroupId = 1,
                    ProfileRole = Role.member,
                    ProfileId = 1,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 1,
                    ProfileRole = Role.administrator,
                    ProfileId = 2,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 1,
                    ProfileRole = Role.owner,
                    ProfileId = 3,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 2,
                    ProfileRole = Role.member,
                    ProfileId = 4,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 2,
                    ProfileRole = Role.owner,
                    ProfileId = 5,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 3,
                    ProfileRole = Role.member,
                    ProfileId = 6,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileSubgroupRelation
                {
                    SubgroupId = 3,
                    ProfileRole = Role.owner,
                    ProfileId = 7,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                }
                );
        }
    }
}
