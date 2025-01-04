using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JPAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8cfa56e3-a327-4ff3-ab44-6466b52436fc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e12a5a55-5fd6-45ed-8cb0-87ff332782a3");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "084ecc7e-918b-44c2-8d7f-ca286aced42c", "2722a0ac-6827-492e-ba1a-b409d72ed6a7", "Recruiter", "RECRUITER" },
                    { "191badb4-9708-4924-a646-88af697efb3b", "93a5a3ac-0de2-4150-b14c-91c66270137e", "Applicant", "APPLICANT" }
                });
        }
    }
}
