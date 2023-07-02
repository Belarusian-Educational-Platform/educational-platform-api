using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class GroupContextConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasData
                (
                    new Group
                    {
                        Id = 1,
                        Name = "Blueberries"
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "Fireflies"
                    },
                    new Group
                    {
                        Id = 3,
                        Name = "Thunderbolts"
                    }
                );
        }
    }
}
