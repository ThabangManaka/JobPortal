using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedApplicantDetailforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ApplicantDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "ApplicantDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "ApplicantDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ApplicantDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_PostID",
                table: "ApplicantDetails",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_UserId",
                table: "ApplicantDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_JobPosts_PostID",
                table: "ApplicantDetails",
                column: "PostID",
                principalTable: "JobPosts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_Users_UserId",
                table: "ApplicantDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_JobPosts_PostID",
                table: "ApplicantDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_Users_UserId",
                table: "ApplicantDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_PostID",
                table: "ApplicantDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_UserId",
                table: "ApplicantDetails");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ApplicantDetails");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "ApplicantDetails");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "ApplicantDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApplicantDetails");
        }
    }
}
