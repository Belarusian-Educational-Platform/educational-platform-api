﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace educational_platform_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroupOrganizationRelations",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOrganizationRelations", x => new { x.GroupId, x.OrganizationId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfileGroupRelations",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ProfileRole = table.Column<int>(type: "int", nullable: false),
                    Permissions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileGroupRelations", x => new { x.ProfileId, x.GroupId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfileOrganizationRelations",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Permissions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileOrganizationRelations", x => new { x.ProfileId, x.OrganizationId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    KeycloakId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfileSubgroupRelations",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    SubgroupId = table.Column<int>(type: "int", nullable: false),
                    ProfileRole = table.Column<int>(type: "int", nullable: false),
                    Permissions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSubgroupRelations", x => new { x.ProfileId, x.SubgroupId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subgroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgroups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "GroupOrganizationRelations",
                columns: new[] { "GroupId", "OrganizationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "11B" },
                    { 2, "9F" },
                    { 3, "8Th" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "Kyiv Natural Science Lyceum No. 145 is a secondary educational institution located in Pechersk District of Kyiv, Ukraine. The program of study emphasizes Physics, Mathematics, Computer Science and Chemistry1. The school’s address is 46 Shota Rustaveli Street Pechersk Raion , Kyiv , 01033 Ukraine1. ", 53.893309000000002, 27.567422000000001, "Kyiv Natural Science Lyceum No. 145" },
                    { 2, "Meridian International School is a private school located in Kyiv, Ukraine. It was established in 20012. Unfortunately, I could not find the exact address or coordinates of the school.\r\n\r\n", 53.893034, 27.567443999999998, "Meridian International School" },
                    { 3, "Kyiv Secondary School No. 189 is a public school located in Kyiv, Ukraine. Unfortunately, I could not find any information on the program of study or the exact address or coordinates of the school.\r\n\r\n", 53.893034, 27.567454000000001, "Kyiv Secondary School No. 189" }
                });

            migrationBuilder.InsertData(
                table: "ProfileGroupRelations",
                columns: new[] { "GroupId", "ProfileId", "Permissions", "ProfileRole" },
                values: new object[,]
                {
                    { 1, 1, "[\"view-private-information\"]", 2 },
                    { 1, 2, "[\"view-private-information\"]", 1 },
                    { 1, 3, "[\"update\",\"view-private-information\"]", 0 },
                    { 2, 4, "[\"view-private-information\"]", 2 },
                    { 2, 5, "[\"update\",\"view-private-information\"]", 0 },
                    { 3, 6, "[\"view-private-information\"]", 2 },
                    { 3, 7, "[\"update\",\"view-private-information\"]", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProfileOrganizationRelations",
                columns: new[] { "OrganizationId", "ProfileId", "Permissions" },
                values: new object[,]
                {
                    { 1, 1, "[\"view-private-information\"]" },
                    { 1, 2, "[\"view-private-information\"]" },
                    { 1, 3, "[\"update\",\"view-private-information\"]" },
                    { 2, 4, "[\"view-private-information\"]" },
                    { 2, 5, "[\"view-private-information\"]" },
                    { 3, 6, "[\"view-private-information\"]" },
                    { 3, 7, "[\"view-private-information\"]" }
                });

            migrationBuilder.InsertData(
                table: "ProfileSubgroupRelations",
                columns: new[] { "ProfileId", "SubgroupId", "Permissions", "ProfileRole" },
                values: new object[,]
                {
                    { 1, 1, "[\"view-private-information\"]", 2 },
                    { 2, 1, "[\"view-private-information\"]", 1 },
                    { 3, 1, "[\"view-private-information\"]", 0 },
                    { 4, 2, "[\"view-private-information\"]", 2 },
                    { 5, 2, "[\"view-private-information\"]", 0 },
                    { 6, 3, "[\"view-private-information\"]", 2 },
                    { 7, 3, "[\"view-private-information\"]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "ContactEmail", "ContactPhone", "IsActive", "KeycloakId", "OrganizationId", "Type" },
                values: new object[,]
                {
                    { 1, "hotjames4u@quebecstart.com", "+375 29 403-72-60", true, "c9c5c403-280e-491a-9217-e60a04022b7f", 1, 0 },
                    { 2, "reiianx@gasss.net", "+375 44 164-23-69", false, "c9c5c403-280e-491a-9217-e60a04022b7f", 1, 0 },
                    { 3, "kxarmark@cbdnut.net", "+375 29 352-28-10", true, "c9c5c403-280e-491a-9217-e60a04022b7g", 1, 1 },
                    { 4, "imamikonyan@sannyfeina.art", "+375 33 938-46-86", false, "c9c5c403-280e-491a-9217-e60a04022b7g", 2, 0 },
                    { 5, "franicomunication@gmisow.com", "+375 29 609-07-74", false, "c9c5c403-280e-491a-9217-e60a04022b7g", 2, 1 },
                    { 6, "psylio@yagatekimi.com", "+375 29 415-46-04", true, "c9c5c403-280e-491a-9217-e60a04022b7c", 3, 0 },
                    { 7, "zulu54@pankasyno23.com", "+375 29 865-01-63", true, "c9c5c403-280e-491a-9217-e60a04022b7c", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Subgroups",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[,]
                {
                    { 1, 0, "11B1" },
                    { 2, 0, "9F1" },
                    { 3, 0, "8Th1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupOrganizationRelations");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "ProfileGroupRelations");

            migrationBuilder.DropTable(
                name: "ProfileOrganizationRelations");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfileSubgroupRelations");

            migrationBuilder.DropTable(
                name: "Subgroups");
        }
    }
}
