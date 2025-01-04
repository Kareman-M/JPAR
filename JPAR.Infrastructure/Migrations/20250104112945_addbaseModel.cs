using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JPAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addbaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Recruiters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "JobPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "084ecc7e-918b-44c2-8d7f-ca286aced42c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "191badb4-9708-4924-a646-88af697efb3b");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Applicants");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48e27911-3242-496a-ab98-06561bb3a8f6", "dc1cff0e-dd8a-4543-82a8-78e08b8c5f39", "Recruiter", "RECRUITER" },
                    { "9816af4d-9239-41d6-8ab5-b384fe30f56a", "0c0fe544-bb05-4a85-a944-aec809ed62c9", "Applicant", "APPLICANT" }
                });
        }
    }
}
