using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedJobPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManagerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManagerEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DriversLicenseRequired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BusinessUnitID = table.Column<int>(type: "int", nullable: false),
                    ExperienceID = table.Column<int>(type: "int", nullable: false),
                    QualificationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_JobPosts_BusinessUnits_BusinessUnitID",
                        column: x => x.BusinessUnitID,
                        principalTable: "BusinessUnits",
                        principalColumn: "BusinessUnitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPosts_ExperienceYears_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "ExperienceYears",
                        principalColumn: "ExperienceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPosts_Qualifications_QualificationID",
                        column: x => x.QualificationID,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_BusinessUnitID",
                table: "JobPosts",
                column: "BusinessUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_ExperienceID",
                table: "JobPosts",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_QualificationID",
                table: "JobPosts",
                column: "QualificationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPosts");
        }
    }
}
