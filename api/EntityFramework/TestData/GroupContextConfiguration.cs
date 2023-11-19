using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.EntityFramework.TestData
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
                        Name = "11B"
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "9F"
                    },
                    new Group
                    {
                        Id = 3,
                        Name = "8Th"
                    }
                );
        }
    }
}
