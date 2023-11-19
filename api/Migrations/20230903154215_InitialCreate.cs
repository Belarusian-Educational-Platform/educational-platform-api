using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
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
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KeycloakId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroupOrganizationRelations",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOrganizationRelations", x => new { x.GroupId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_GroupOrganizationRelations_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOrganizationRelations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileGroupRelations", x => new { x.ProfileId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_ProfileGroupRelations_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileGroupRelations_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfileOrganizationRelations",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Permissions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileOrganizationRelations", x => new { x.ProfileId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_ProfileOrganizationRelations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileOrganizationRelations_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "11B" },
                    { 2, false, "9F" },
                    { 3, false, "8Th" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "IsDeleted", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "Kyiv Natural Science Lyceum No. 145 is a secondary educational institution located in Pechersk District of Kyiv, Ukraine. The program of study emphasizes Physics, Mathematics, Computer Science and Chemistry1. The school’s address is 46 Shota Rustaveli Street Pechersk Raion , Kyiv , 01033 Ukraine1. ", false, 53.893309000000002, 27.567422000000001, "Kyiv Natural Science Lyceum No. 145" },
                    { 2, "Meridian International School is a private school located in Kyiv, Ukraine. It was established in 20012. Unfortunately, I could not find the exact address or coordinates of the school.\r\n\r\n", false, 53.893034, 27.567443999999998, "Meridian International School" },
                    { 3, "Kyiv Secondary School No. 189 is a public school located in Kyiv, Ukraine. Unfortunately, I could not find any information on the program of study or the exact address or coordinates of the school.\r\n\r\n", false, 53.893034, 27.567454000000001, "Kyiv Secondary School No. 189" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Birthday", "ContactEmail", "ContactPhone", "FirstName", "IsActive", "IsDeleted", "KeycloakId", "LastName", "Surname", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2004, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "hotjames4u@quebecstart.com", "+375 29 403-72-60", "Daniil", true, false, "c9c5c403-280e-491a-9217-e60a04022b7f", "Kananenka", "Alexandrovich", 0 },
                    { 2, new DateTime(2010, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "reiianx@gasss.net", "+375 44 164-23-69", "Karyna", false, false, "c9c5c403-280e-491a-9217-e60a04022b7f", "Novik", "Tsimur", 0 },
                    { 3, new DateTime(1990, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "kxarmark@cbdnut.net", "+375 29 352-28-10", "Tsimur", true, false, "c9c5c403-280e-491a-9217-e60a04022b7g", "Kavalioŭ", "Henadz", 1 },
                    { 4, new DateTime(2008, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "imamikonyan@sannyfeina.art", "+375 33 938-46-86", "Artur", false, false, "c9c5c403-280e-491a-9217-e60a04022b7g", "Kazlow", " Iryna", 0 },
                    { 5, new DateTime(1975, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "franicomunication@gmisow.com", "+375 29 609-07-74", "Yan", false, false, "c9c5c403-280e-491a-9217-e60a04022b7g", "Kavalioŭ", "Marta", 1 },
                    { 6, new DateTime(2011, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "psylio@yagatekimi.com", "+375 29 415-46-04", "Karyna", true, false, "c9c5c403-280e-491a-9217-e60a04022b7c", "Ivanow", " Ilia", 0 },
                    { 7, new DateTime(1994, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "zulu54@pankasyno23.com", "+375 29 865-01-63", "Hleb", true, false, "c9c5c403-280e-491a-9217-e60a04022b7c", "Ivanow", "Kira", 1 }
                });

            migrationBuilder.InsertData(
                table: "GroupOrganizationRelations",
                columns: new[] { "GroupId", "OrganizationId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, false },
                    { 2, 2, false },
                    { 3, 3, false }
                });

            migrationBuilder.InsertData(
                table: "ProfileGroupRelations",
                columns: new[] { "GroupId", "ProfileId", "IsDeleted", "Permissions", "ProfileRole" },
                values: new object[,]
                {
                    { 1, 1, false, "[\"view-private-information\"]", 2 },
                    { 1, 2, false, "[\"view-private-information\"]", 1 },
                    { 1, 3, false, "[\"update\",\"view-private-information\"]", 0 },
                    { 2, 4, false, "[\"view-private-information\"]", 2 },
                    { 2, 5, false, "[\"update\",\"view-private-information\"]", 0 },
                    { 3, 6, false, "[\"view-private-information\"]", 2 },
                    { 3, 7, false, "[\"update\",\"view-private-information\"]", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProfileOrganizationRelations",
                columns: new[] { "OrganizationId", "ProfileId", "IsDeleted", "Permissions" },
                values: new object[,]
                {
                    { 1, 1, false, "[\"view-private-information\",\"update\",\"edit-profiles-permissions\",\"edit-group-profiles-permissions\",\"create-profiles\",\"delete-profiles\", \"create-groups\", \"delete-groups\",\"update-groups\"]" },
                    { 1, 2, false, "[\"view-private-information\"]" },
                    { 1, 3, false, "[\"update\",\"view-private-information\"]" },
                    { 2, 4, false, "[\"view-private-information\"]" },
                    { 2, 5, false, "[\"view-private-information\"]" },
                    { 3, 6, false, "[\"view-private-information\"]" },
                    { 3, 7, false, "[\"view-private-information\"]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupOrganizationRelations_GroupId",
                table: "GroupOrganizationRelations",
                column: "GroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupOrganizationRelations_OrganizationId",
                table: "GroupOrganizationRelations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileGroupRelations_GroupId",
                table: "ProfileGroupRelations",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOrganizationRelations_OrganizationId",
                table: "ProfileOrganizationRelations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOrganizationRelations_ProfileId",
                table: "ProfileOrganizationRelations",
                column: "ProfileId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupOrganizationRelations");

            migrationBuilder.DropTable(
                name: "ProfileGroupRelations");

            migrationBuilder.DropTable(
                name: "ProfileOrganizationRelations");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
