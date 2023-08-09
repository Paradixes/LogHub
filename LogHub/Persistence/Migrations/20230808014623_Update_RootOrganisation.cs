using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_RootOrganisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RootOrganisationId",
                table: "Organisations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_RootOrganisationId",
                table: "Organisations",
                column: "RootOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Organisations_RootOrganisationId",
                table: "Organisations",
                column: "RootOrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Organisations_RootOrganisationId",
                table: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_Organisations_RootOrganisationId",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "RootOrganisationId",
                table: "Organisations");
        }
    }
}
