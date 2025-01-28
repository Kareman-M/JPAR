using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JPAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStage",
                table: "ApplicationStage");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "02323f4f-477a-4566-9159-32662862cfbf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d2b15f7-1de6-4f6e-be0a-e0383c6d7b24");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStage",
                table: "ApplicationStage",
                columns: new[] { "ApplicantId", "JobId", "Stage" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "526fe92b-eef4-46ff-8604-57cfb8396fe5", "9b43f60e-1d8f-4688-b5af-2942e92ddc05", "Recruiter", "RECRUITER" },
                    { "819a87e9-7179-4be6-b34e-349d9202e471", "69114520-dd10-479f-a20d-3c88723cd0f5", "Applicant", "APPLICANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStage",
                table: "ApplicationStage");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "526fe92b-eef4-46ff-8604-57cfb8396fe5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "819a87e9-7179-4be6-b34e-349d9202e471");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStage",
                table: "ApplicationStage",
                columns: new[] { "ApplicantId", "JobId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02323f4f-477a-4566-9159-32662862cfbf", "21e748e5-f9bb-43cd-bec7-405a866bf10e", "Applicant", "APPLICANT" },
                    { "7d2b15f7-1de6-4f6e-be0a-e0383c6d7b24", "051aaad4-2500-4e1c-aa29-e3ad20a5352c", "Recruiter", "RECRUITER" }
                });
        }
    }
}
