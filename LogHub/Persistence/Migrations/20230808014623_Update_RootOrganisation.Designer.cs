﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(LogHubDbContext))]
    [Migration("20230808014623_Update_RootOrganisation")]
    partial class Update_RootOrganisation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Behaviours.Actions.RecordAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InitiatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InitiatorId");

                    b.HasIndex("RecordId");

                    b.ToTable("RecordActions");
                });

            modelBuilder.Entity("Domain.Entities.Behaviours.Requests.RecordRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Command")
                        .HasColumnType("int");

                    b.Property<Guid>("HandlerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InitiatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HandlerId");

                    b.HasIndex("InitiatorId");

                    b.HasIndex("RecordId");

                    b.ToTable("RecordRequests");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.DocEditor", b =>
                {
                    b.Property<Guid>("DocId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DocId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DocEditors");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.DocLabel", b =>
                {
                    b.Property<Guid>("DocId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LabelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DocId", "LabelId");

                    b.HasIndex("LabelId");

                    b.ToTable("DocLabels");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.FavouriteDoc", b =>
                {
                    b.Property<Guid>("DocId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DocId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavouriteDocs");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.OrganisationMembership", b =>
                {
                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("OrganisationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OrganisationMemberships");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.RecordCommandHandler", b =>
                {
                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Command")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("RecordId", "Command");

                    b.ToTable("RecordCommandHandlers");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.RecordPermission", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RecordId");

                    b.HasIndex("RecordId");

                    b.ToTable("RecordPermissions");
                });

            modelBuilder.Entity("Domain.Entities.Organisations.Organisation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvitationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentOrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RootOrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentOrganisationId");

                    b.HasIndex("RootOrganisationId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DataManagementPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DataManagementPlanId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Domain.Entities.Records.Labels.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("Domain.Entities.Records.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Records");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orcid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.DataManagementPlanTemplate", b =>
                {
                    b.HasBaseType("Domain.Entities.Records.Record");

                    b.Property<Guid?>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("OrganisationId");

                    b.ToTable("DataManagementPlanTemplates", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Records.Docs.Document", b =>
                {
                    b.HasBaseType("Domain.Entities.Records.Record");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LogbookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasIndex("LogbookId");

                    b.ToTable("Documents", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Records.Logbooks.Logbook", b =>
                {
                    b.HasBaseType("Domain.Entities.Records.Record");

                    b.Property<string>("CoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Logbooks", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Records.Repositories.Repository", b =>
                {
                    b.HasBaseType("Domain.Entities.Records.Record");

                    b.Property<Guid>("DataManagementPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("DataManagementPlanId")
                        .IsUnique()
                        .HasFilter("[DataManagementPlanId] IS NOT NULL");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Repositories", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.DataManagementPlan", b =>
                {
                    b.HasBaseType("Domain.Entities.Records.DataManagementPlans.DataManagementPlanTemplate");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("DataManagementPlans", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Behaviours.Actions.RecordAction", b =>
                {
                    b.HasOne("Domain.Entities.Users.User", "Initiator")
                        .WithMany("RecordActions")
                        .HasForeignKey("InitiatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Records.Record", "Record")
                        .WithMany("Actions")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Initiator");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Domain.Entities.Behaviours.Requests.RecordRequest", b =>
                {
                    b.HasOne("Domain.Entities.Users.User", "Handler")
                        .WithMany("RequestToHandle")
                        .HasForeignKey("HandlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users.User", "Initiator")
                        .WithMany("RequestToInitiate")
                        .HasForeignKey("InitiatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Records.Record", "Record")
                        .WithMany("Requests")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Handler");

                    b.Navigation("Initiator");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.DocEditor", b =>
                {
                    b.HasOne("Domain.Entities.Records.Docs.Document", "Doc")
                        .WithMany("Editors")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doc");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.DocLabel", b =>
                {
                    b.HasOne("Domain.Entities.Records.Docs.Document", "Doc")
                        .WithMany("Labels")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Records.Labels.Label", "Label")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doc");

                    b.Navigation("Label");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.FavouriteDoc", b =>
                {
                    b.HasOne("Domain.Entities.Records.Docs.Document", "Doc")
                        .WithMany()
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users.User", "User")
                        .WithMany("FavouriteDocs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doc");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.OrganisationMembership", b =>
                {
                    b.HasOne("Domain.Entities.Organisations.Organisation", "Organisation")
                        .WithMany("Memberships")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users.User", "User")
                        .WithMany("OrganisationMemberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.RecordCommandHandler", b =>
                {
                    b.HasOne("Domain.Entities.Records.Record", "Record")
                        .WithMany("CommandHandlers")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Domain.Entities.Middlewares.RecordPermission", b =>
                {
                    b.HasOne("Domain.Entities.Records.Record", "Record")
                        .WithMany("Permissions")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users.User", "User")
                        .WithMany("RecordPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Organisations.Organisation", b =>
                {
                    b.HasOne("Domain.Entities.Organisations.Organisation", "ParentOrganisation")
                        .WithMany("SubOrganisations")
                        .HasForeignKey("ParentOrganisationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.Organisations.Organisation", "RootOrganisation")
                        .WithMany()
                        .HasForeignKey("RootOrganisationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentOrganisation");

                    b.Navigation("RootOrganisation");
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.Question", b =>
                {
                    b.HasOne("Domain.Entities.Records.DataManagementPlans.DataManagementPlan", "DataManagementPlan")
                        .WithMany("Questions")
                        .HasForeignKey("DataManagementPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataManagementPlan");
                });

            modelBuilder.Entity("Domain.Entities.Records.Labels.Label", b =>
                {
                    b.HasOne("Domain.Entities.Records.Repositories.Repository", null)
                        .WithMany("Labels")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Records.Record", b =>
                {
                    b.HasOne("Domain.Entities.Users.User", null)
                        .WithMany("Records")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Entities.Users.User", b =>
                {
                    b.OwnsOne("Domain.Entities.Users.UserPreference", "UserPreference", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("AutoSave")
                                .HasColumnType("bit");

                            b1.Property<bool>("EmailNotification")
                                .HasColumnType("bit");

                            b1.Property<int>("FontSize")
                                .HasColumnType("int");

                            b1.Property<int>("Theme")
                                .HasColumnType("int");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("UserPreference")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.DataManagementPlanTemplate", b =>
                {
                    b.HasOne("Domain.Entities.Records.Record", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Records.DataManagementPlans.DataManagementPlanTemplate", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Organisations.Organisation", "Organisation")
                        .WithMany("DataManagementPlanTemplates")
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("Domain.Entities.Records.Docs.Document", b =>
                {
                    b.HasOne("Domain.Entities.Records.Record", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Records.Docs.Document", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Records.Logbooks.Logbook", "Logbook")
                        .WithMany("Documents")
                        .HasForeignKey("LogbookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logbook");
                });

            modelBuilder.Entity("Domain.Entities.Records.Logbooks.Logbook", b =>
                {
                    b.HasOne("Domain.Entities.Records.Record", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Records.Logbooks.Logbook", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Records.Repositories.Repository", "Repository")
                        .WithMany("Logbooks")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("Domain.Entities.Records.Repositories.Repository", b =>
                {
                    b.HasOne("Domain.Entities.Records.DataManagementPlans.DataManagementPlan", "DataManagementPlan")
                        .WithOne("Repository")
                        .HasForeignKey("Domain.Entities.Records.Repositories.Repository", "DataManagementPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Records.Record", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Records.Repositories.Repository", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Organisations.Organisation", "Organisation")
                        .WithMany("Repositories")
                        .HasForeignKey("OrganisationId");

                    b.Navigation("DataManagementPlan");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.DataManagementPlan", b =>
                {
                    b.HasOne("Domain.Entities.Records.DataManagementPlans.DataManagementPlanTemplate", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Records.DataManagementPlans.DataManagementPlan", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Organisations.Organisation", b =>
                {
                    b.Navigation("DataManagementPlanTemplates");

                    b.Navigation("Memberships");

                    b.Navigation("Repositories");

                    b.Navigation("SubOrganisations");
                });

            modelBuilder.Entity("Domain.Entities.Records.Record", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("CommandHandlers");

                    b.Navigation("Permissions");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.Users.User", b =>
                {
                    b.Navigation("FavouriteDocs");

                    b.Navigation("OrganisationMemberships");

                    b.Navigation("RecordActions");

                    b.Navigation("RecordPermissions");

                    b.Navigation("Records");

                    b.Navigation("RequestToHandle");

                    b.Navigation("RequestToInitiate");
                });

            modelBuilder.Entity("Domain.Entities.Records.Docs.Document", b =>
                {
                    b.Navigation("Editors");

                    b.Navigation("Labels");
                });

            modelBuilder.Entity("Domain.Entities.Records.Logbooks.Logbook", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Domain.Entities.Records.Repositories.Repository", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Logbooks");
                });

            modelBuilder.Entity("Domain.Entities.Records.DataManagementPlans.DataManagementPlan", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Repository");
                });
#pragma warning restore 612, 618
        }
    }
}
