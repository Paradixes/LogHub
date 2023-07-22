using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Relation_Base_Dmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DmpId",
                table: "Bases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Bases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_DmpId",
                table: "Bases",
                column: "DmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_DataManagementPlanTemplates_DmpId",
                table: "Bases",
                column: "DmpId",
                principalTable: "DataManagementPlanTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_DataManagementPlanTemplates_DmpId",
                table: "Bases");

            migrationBuilder.DropIndex(
                name: "IX_Bases_DmpId",
                table: "Bases");

            migrationBuilder.DropColumn(
                name: "DmpId",
                table: "Bases");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Bases");
        }
    }
}
