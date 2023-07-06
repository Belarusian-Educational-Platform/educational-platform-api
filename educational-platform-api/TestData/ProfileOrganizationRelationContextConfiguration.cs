using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class ProfileOrganizationRelationContextConfiguration : IEntityTypeConfiguration<ProfileOrganizationRelation>
    {
        public void Configure(EntityTypeBuilder<ProfileOrganizationRelation> builder)
        {
            builder
                .HasData(
                new ProfileOrganizationRelation
                {
                    OrganizationId = 1,
                    ProfileId = 1,
                    Permissions= "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 1,
                    ProfileId = 2,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 1,
                    ProfileId = 3,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 2,
                    ProfileId = 4,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 2,
                    ProfileId = 5,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 3,
                    ProfileId = 6,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 3,
                    ProfileId = 7,
                    Permissions = "{\r\n  \"Permissions\": [\r\n    {\r\n      \"a\": \"true\"\r\n    },\r\n    {\r\n      \"b\": \"true\"\r\n    },\r\n    {\r\n      \"c\": \"false\"\r\n    }\r\n  ]\r\n}"
                }
                );
        }
    }
}
