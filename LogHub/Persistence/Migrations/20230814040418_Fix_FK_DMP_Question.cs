using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix_FK_DMP_Question : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DataManagementPlans_DataManagementPlanId",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DataManagementPlanTemplates_DataManagementPlanId",
                table: "Questions",
                column: "DataManagementPlanId",
                principalTable: "DataManagementPlanTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DataManagementPlanTemplates_DataManagementPlanId",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DataManagementPlans_DataManagementPlanId",
                table: "Questions",
                column: "DataManagementPlanId",
                principalTable: "DataManagementPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
