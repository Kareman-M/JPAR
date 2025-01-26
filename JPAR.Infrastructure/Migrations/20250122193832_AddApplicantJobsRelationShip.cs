using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JPAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantJobsRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ApplicantJob",
                columns: table => new
                {
                    ApplicantsId = table.Column<int>(type: "int", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJob", x => new { x.ApplicantsId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_ApplicantJob_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantJob_JobPosts_JobsId",
                        column: x => x.JobsId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJob_JobsId",
                table: "ApplicantJob",
                column: "JobsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJob");
        }
    }
}
