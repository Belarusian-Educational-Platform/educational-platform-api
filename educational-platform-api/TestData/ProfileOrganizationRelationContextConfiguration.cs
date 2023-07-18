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
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 1,
                    ProfileId = 2,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 1,
                    ProfileId = 3,
                    Permissions= "{\"Permissions\":[\"update\",\"view-private-information\"]}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 2,
                    ProfileId = 4,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 2,
                    ProfileId = 5,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 3,
                    ProfileId = 6,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                },
                new ProfileOrganizationRelation
                {
                    OrganizationId = 3,
                    ProfileId = 7,
                    Permissions= "{\"Permissions\":[\"view-private-information\"]}"
                }
                );
        }
    }
}
