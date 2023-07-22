using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    BaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandlerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labels_Bases_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logbooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logbooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logbooks_Bases_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogbookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Logbooks_LogbookId",
                        column: x => x.LogbookId,
                        principalTable: "Logbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocEditors",
                columns: table => new
                {
                    DocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocEditors", x => new { x.DocId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DocEditors_Documents_DocId",
                        column: x => x.DocId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocLabels",
                columns: table => new
                {
                    DocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocLabels", x => new { x.DocId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_DocLabels_Documents_DocId",
                        column: x => x.DocId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataManagementPlanActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataManagementPlanActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataManagementPlanPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DataManagementPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataManagementPlanPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataManagementPlanRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandlerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataManagementPlanRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataManagementPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataManagementPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataManagementPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_DataManagementPlans_DataManagementPlanId",
                        column: x => x.DataManagementPlanId,
                        principalTable: "DataManagementPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_DataManagementPlans_DmpId",
                        column: x => x.DmpId,
                        principalTable: "DataManagementPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocActions_Documents_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocPermissions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocPermissions_Documents_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandlerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocRequests_Documents_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavouriteDocs",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteDocs", x => new { x.DocId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "LogbookActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogbookActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogbookActions_Logbooks_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Logbooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogbookPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LogbookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogbookPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogbookPermissions_Logbooks_LogbookId",
                        column: x => x.LogbookId,
                        principalTable: "Logbooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogbookPermissions_Logbooks_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Logbooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogbookRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandlerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogbookRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogbookRequests_Logbooks_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Logbooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OrganisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orcid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserSetting_Theme = table.Column<int>(type: "int", nullable: false),
                    UserSetting_EmailNotification = table.Column<bool>(type: "bit", nullable: false),
                    UserSetting_AutoSave = table.Column<bool>(type: "bit", nullable: false),
                    UserSetting_FontSize = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseActions_InitiatorId",
                table: "BaseActions",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseActions_RecordId",
                table: "BaseActions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePermissions_BaseId",
                table: "BasePermissions",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePermissions_RecordId",
                table: "BasePermissions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePermissions_UserId",
                table: "BasePermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_HandlerId",
                table: "BaseRequests",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_InitiatorId",
                table: "BaseRequests",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_RecordId",
                table: "BaseRequests",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_OrganisationId",
                table: "Bases",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanActions_InitiatorId",
                table: "DataManagementPlanActions",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanActions_RecordId",
                table: "DataManagementPlanActions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanPermissions_DataManagementPlanId",
                table: "DataManagementPlanPermissions",
                column: "DataManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanPermissions_RecordId",
                table: "DataManagementPlanPermissions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanPermissions_UserId",
                table: "DataManagementPlanPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanRequests_HandlerId",
                table: "DataManagementPlanRequests",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanRequests_InitiatorId",
                table: "DataManagementPlanRequests",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlanRequests_RecordId",
                table: "DataManagementPlanRequests",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DataManagementPlans_OrganisationId",
                table: "DataManagementPlans",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerId",
                table: "Department",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_OrganisationId",
                table: "Department",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocActions_InitiatorId",
                table: "DocActions",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DocActions_RecordId",
                table: "DocActions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DocPermissions_DocumentId",
                table: "DocPermissions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocPermissions_RecordId",
                table: "DocPermissions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DocPermissions_UserId",
                table: "DocPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocRequests_HandlerId",
                table: "DocRequests",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_DocRequests_InitiatorId",
                table: "DocRequests",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DocRequests_RecordId",
                table: "DocRequests",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LogbookId",
                table: "Documents",
                column: "LogbookId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteDocs_UserId",
                table: "FavouriteDocs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_BaseId",
                table: "Labels",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookActions_InitiatorId",
                table: "LogbookActions",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookActions_RecordId",
                table: "LogbookActions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookPermissions_LogbookId",
                table: "LogbookPermissions",
                column: "LogbookId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookPermissions_RecordId",
                table: "LogbookPermissions",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookPermissions_UserId",
                table: "LogbookPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookRequests_HandlerId",
                table: "LogbookRequests",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookRequests_InitiatorId",
                table: "LogbookRequests",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LogbookRequests_RecordId",
                table: "LogbookRequests",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Logbooks_BaseId",
                table: "Logbooks",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ManagerId",
                table: "Organisations",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DataManagementPlanId",
                table: "Questions",
                column: "DataManagementPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DmpId",
                table: "Questions",
                column: "DmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganisationId",
                table: "Users",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActions_Bases_RecordId",
                table: "BaseActions",
                column: "RecordId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActions_Users_InitiatorId",
                table: "BaseActions",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasePermissions_Bases_BaseId",
                table: "BasePermissions",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePermissions_Bases_RecordId",
                table: "BasePermissions",
                column: "RecordId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePermissions_Users_UserId",
                table: "BasePermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseRequests_Bases_RecordId",
                table: "BaseRequests",
                column: "RecordId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseRequests_Users_HandlerId",
                table: "BaseRequests",
                column: "HandlerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseRequests_Users_InitiatorId",
                table: "BaseRequests",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Organisations_OrganisationId",
                table: "Bases",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanActions_DataManagementPlans_RecordId",
                table: "DataManagementPlanActions",
                column: "RecordId",
                principalTable: "DataManagementPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanActions_Users_InitiatorId",
                table: "DataManagementPlanActions",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanPermissions_DataManagementPlans_DataManagementPlanId",
                table: "DataManagementPlanPermissions",
                column: "DataManagementPlanId",
                principalTable: "DataManagementPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanPermissions_DataManagementPlans_RecordId",
                table: "DataManagementPlanPermissions",
                column: "RecordId",
                principalTable: "DataManagementPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanPermissions_Users_UserId",
                table: "DataManagementPlanPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanRequests_DataManagementPlans_RecordId",
                table: "DataManagementPlanRequests",
                column: "RecordId",
                principalTable: "DataManagementPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanRequests_Users_HandlerId",
                table: "DataManagementPlanRequests",
                column: "HandlerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlanRequests_Users_InitiatorId",
                table: "DataManagementPlanRequests",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataManagementPlans_Organisations_OrganisationId",
                table: "DataManagementPlans",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Organisations_OrganisationId",
                table: "Department",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Users_ManagerId",
                table: "Department",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocActions_Users_InitiatorId",
                table: "DocActions",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocPermissions_Users_UserId",
                table: "DocPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocRequests_Users_HandlerId",
                table: "DocRequests",
                column: "HandlerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocRequests_Users_InitiatorId",
                table: "DocRequests",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteDocs_Users_UserId",
                table: "FavouriteDocs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogbookActions_Users_InitiatorId",
                table: "LogbookActions",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogbookPermissions_Users_UserId",
                table: "LogbookPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogbookRequests_Users_HandlerId",
                table: "LogbookRequests",
                column: "HandlerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogbookRequests_Users_InitiatorId",
                table: "LogbookRequests",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Users_ManagerId",
                table: "Organisations",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Users_ManagerId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Users_ManagerId",
                table: "Organisations");

            migrationBuilder.DropTable(
                name: "BaseActions");

            migrationBuilder.DropTable(
                name: "BasePermissions");

            migrationBuilder.DropTable(
                name: "BaseRequests");

            migrationBuilder.DropTable(
                name: "DataManagementPlanActions");

            migrationBuilder.DropTable(
                name: "DataManagementPlanPermissions");

            migrationBuilder.DropTable(
                name: "DataManagementPlanRequests");

            migrationBuilder.DropTable(
                name: "DocActions");

            migrationBuilder.DropTable(
                name: "DocEditors");

            migrationBuilder.DropTable(
                name: "DocLabels");

            migrationBuilder.DropTable(
                name: "DocPermissions");

            migrationBuilder.DropTable(
                name: "DocRequests");

            migrationBuilder.DropTable(
                name: "FavouriteDocs");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "LogbookActions");

            migrationBuilder.DropTable(
                name: "LogbookPermissions");

            migrationBuilder.DropTable(
                name: "LogbookRequests");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DataManagementPlans");

            migrationBuilder.DropTable(
                name: "Logbooks");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
