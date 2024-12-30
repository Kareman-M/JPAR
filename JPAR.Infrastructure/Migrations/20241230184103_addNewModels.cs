using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JPAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerLevel = table.Column<int>(type: "int", nullable: false),
                    MinYearsOfExperince = table.Column<int>(type: "int", nullable: false),
                    MaxYearsOfExperince = table.Column<int>(type: "int", nullable: false),
                    MinSalaryRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxSalaryRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HideSalary = table.Column<bool>(type: "bit", nullable: false),
                    AdditinalSalaryDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumberOfVecancy = table.Column<int>(type: "int", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruiterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    JobPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantJob_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplicantJob_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJob_ApplicantId",
                table: "ApplicantJob",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJob_JobPostId",
                table: "ApplicantJob",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_RecruiterId",
                table: "JobPosts",
                column: "RecruiterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJob");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "48e27911-3242-496a-ab98-06561bb3a8f6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9816af4d-9239-41d6-8ab5-b384fe30f56a");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0456a481-cc77-4e97-9d6d-8cb418dee5e6", "ad915c36-059d-484e-8daf-e2179ecc39b1", "Recruiter", "RECRUITER" },
                    { "99ddcec3-3808-4cdc-b687-d97808fff77e", "1efa9f3a-ca6b-431b-86bb-3bb3bcbf1d2a", "Applicant", "APPLICANT" }
                });
        }
    }
}
