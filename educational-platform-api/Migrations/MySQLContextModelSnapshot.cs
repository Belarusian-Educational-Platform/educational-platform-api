﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using educational_platform_api.Contexts;

#nullable disable

namespace educational_platform_api.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("educational_platform_api.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "11B"
                        },
                        new
                        {
                            Id = 2,
                            Name = "9F"
                        },
                        new
                        {
                            Id = 3,
                            Name = "8Th"
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.GroupOrganizationRelation", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "OrganizationId");

                    b.ToTable("GroupOrganizationRelations");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            OrganizationId = 1
                        },
                        new
                        {
                            GroupId = 2,
                            OrganizationId = 2
                        },
                        new
                        {
                            GroupId = 3,
                            OrganizationId = 3
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Kyiv Natural Science Lyceum No. 145 is a secondary educational institution located in Pechersk District of Kyiv, Ukraine. The program of study emphasizes Physics, Mathematics, Computer Science and Chemistry1. The school’s address is 46 Shota Rustaveli Street Pechersk Raion , Kyiv , 01033 Ukraine1. ",
                            Latitude = 53.893309000000002,
                            Longitude = 27.567422000000001,
                            Name = "Kyiv Natural Science Lyceum No. 145"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Meridian International School is a private school located in Kyiv, Ukraine. It was established in 20012. Unfortunately, I could not find the exact address or coordinates of the school.\r\n\r\n",
                            Latitude = 53.893034,
                            Longitude = 27.567443999999998,
                            Name = "Meridian International School"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kyiv Secondary School No. 189 is a public school located in Kyiv, Ukraine. Unfortunately, I could not find any information on the program of study or the exact address or coordinates of the school.\r\n\r\n",
                            Latitude = 53.893034,
                            Longitude = 27.567454000000001,
                            Name = "Kyiv Secondary School No. 189"
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            ContactEmail = "hotjames4u@quebecstart.com",
                            ContactPhone = "+375 29 403-72-60",
                            OrganizationId = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 2,
                            ContactEmail = "reiianx@gasss.net",
                            ContactPhone = "+375 44 164-23-69",
                            OrganizationId = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 3,
                            ContactEmail = "kxarmark@cbdnut.net",
                            ContactPhone = "+375 29 352-28-10",
                            OrganizationId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 4,
                            ContactEmail = "imamikonyan@sannyfeina.art",
                            ContactPhone = "+375 33 938-46-86",
                            OrganizationId = 2,
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            AccountId = 5,
                            ContactEmail = "franicomunication@gmisow.com",
                            ContactPhone = "+375 29 609-07-74",
                            OrganizationId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            AccountId = 6,
                            ContactEmail = "psylio@yagatekimi.com",
                            ContactPhone = "+375 29 415-46-04",
                            OrganizationId = 3,
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            AccountId = 7,
                            ContactEmail = "zulu54@pankasyno23.com",
                            ContactPhone = "+375 29 865-01-63",
                            OrganizationId = 3,
                            Type = 1
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.ProfileGroupRelation", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProfileRole")
                        .HasColumnType("int");

                    b.HasKey("ProfileId", "GroupId");

                    b.ToTable("ProfileGroupRelations");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            GroupId = 1,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 2
                        },
                        new
                        {
                            ProfileId = 2,
                            GroupId = 1,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 1
                        },
                        new
                        {
                            ProfileId = 3,
                            GroupId = 1,
                            Permissions = "[\"update\",\"view-private-information\"]",
                            ProfileRole = 0
                        },
                        new
                        {
                            ProfileId = 4,
                            GroupId = 2,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 2
                        },
                        new
                        {
                            ProfileId = 5,
                            GroupId = 2,
                            Permissions = "[\"update\",\"view-private-information\"]",
                            ProfileRole = 0
                        },
                        new
                        {
                            ProfileId = 6,
                            GroupId = 3,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 2
                        },
                        new
                        {
                            ProfileId = 7,
                            GroupId = 3,
                            Permissions = "[\"update\",\"view-private-information\"]",
                            ProfileRole = 0
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.ProfileOrganizationRelation", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProfileId", "OrganizationId");

                    b.ToTable("ProfileOrganizationRelations");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            OrganizationId = 1,
                            Permissions = "[\"view-private-information\"]"
                        },
                        new
                        {
                            ProfileId = 2,
                            OrganizationId = 1,
                            Permissions = "[\"view-private-information\"]"
                        },
                        new
                        {
                            ProfileId = 3,
                            OrganizationId = 1,
                            Permissions = "[\"update\",\"view-private-information\"]"
                        },
                        new
                        {
                            ProfileId = 4,
                            OrganizationId = 2,
                            Permissions = "[\"view-private-information\"]"
                        },
                        new
                        {
                            ProfileId = 5,
                            OrganizationId = 2,
                            Permissions = "[\"view-private-information\"]"
                        },
                        new
                        {
                            ProfileId = 6,
                            OrganizationId = 3,
                            Permissions = "[\"view-private-information\"]"
                        },
                        new
                        {
                            ProfileId = 7,
                            OrganizationId = 3,
                            Permissions = "[\"view-private-information\"]"
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.ProfileSubgroupRelation", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("SubgroupId")
                        .HasColumnType("int");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProfileRole")
                        .HasColumnType("int");

                    b.HasKey("ProfileId", "SubgroupId");

                    b.ToTable("ProfileSubgroupRelations");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            SubgroupId = 1,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 2
                        },
                        new
                        {
                            ProfileId = 2,
                            SubgroupId = 1,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 1
                        },
                        new
                        {
                            ProfileId = 3,
                            SubgroupId = 1,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 0
                        },
                        new
                        {
                            ProfileId = 4,
                            SubgroupId = 2,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 2
                        },
                        new
                        {
                            ProfileId = 5,
                            SubgroupId = 2,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 0
                        },
                        new
                        {
                            ProfileId = 6,
                            SubgroupId = 3,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 2
                        },
                        new
                        {
                            ProfileId = 7,
                            SubgroupId = 3,
                            Permissions = "[\"view-private-information\"]",
                            ProfileRole = 0
                        });
                });

            modelBuilder.Entity("educational_platform_api.Models.Subgroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subgroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupId = 0,
                            Name = "11B1"
                        },
                        new
                        {
                            Id = 2,
                            GroupId = 0,
                            Name = "9F1"
                        },
                        new
                        {
                            Id = 3,
                            GroupId = 0,
                            Name = "8Th1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
