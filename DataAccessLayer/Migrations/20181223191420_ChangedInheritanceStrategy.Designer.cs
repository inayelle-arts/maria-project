﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20181223191420_ChangedInheritanceStrategy")]
    partial class ChangedInheritanceStrategy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("App.DAL.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StoragePath");

                    b.HasKey("Id");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("App.DAL.Entities.BacklogTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Priority");

                    b.Property<int?>("ProjectBacklogId");

                    b.Property<int>("RequirementId");

                    b.Property<int?>("SprintBacklogId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectBacklogId");

                    b.HasIndex("RequirementId");

                    b.HasIndex("SprintBacklogId");

                    b.ToTable("BacklogTask");
                });

            modelBuilder.Entity("App.DAL.Entities.BoardBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Boards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BoardBase");
                });

            modelBuilder.Entity("App.DAL.Entities.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("App.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AttachmentsId");

                    b.Property<int>("AuthorId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("TaskId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentsId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TaskId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("App.DAL.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("App.DAL.Entities.ConstraintRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BoardBaseId");

                    b.Property<int?>("ColumnId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("BoardBaseId");

                    b.HasIndex("ColumnId");

                    b.HasIndex("TaskId");

                    b.ToTable("ConstraintRecord");
                });

            modelBuilder.Entity("App.DAL.Entities.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Identifier")
                        .IsRequired();

                    b.Property<int?>("OwnerId");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("App.DAL.Entities.Cooperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("EndOfCooperation");

                    b.Property<int>("MemberId");

                    b.Property<DateTime>("StartOfCooperation");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MemberId");

                    b.ToTable("Cooperation");
                });

            modelBuilder.Entity("App.DAL.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("App.DAL.Entities.HistoryPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Event")
                        .IsRequired();

                    b.Property<int>("HistoryId");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.ToTable("HistoryPoint");
                });

            modelBuilder.Entity("App.DAL.Entities.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<string>("Name");

                    b.Property<int?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("TaskId");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("App.DAL.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BacklogId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProjectRootId");

                    b.Property<int>("RequirementICollectionId");

                    b.HasKey("Id");

                    b.HasIndex("BacklogId")
                        .IsUnique();

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectRootId");

                    b.HasIndex("RequirementICollectionId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("App.DAL.Entities.ProjectBacklog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("ProjectBacklog");
                });

            modelBuilder.Entity("App.DAL.Entities.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Priority");

                    b.Property<int>("RequirementICollectionId");

                    b.HasKey("Id");

                    b.HasIndex("RequirementICollectionId");

                    b.ToTable("Requirement");
                });

            modelBuilder.Entity("App.DAL.Entities.RequirementICollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("RequirementICollection");
                });

            modelBuilder.Entity("App.DAL.Entities.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("SprintBacklogId");

                    b.Property<int>("StoryPointsActual");

                    b.Property<int>("StoryPointsExpected");

                    b.HasKey("Id");

                    b.HasIndex("SprintBacklogId")
                        .IsUnique();

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("App.DAL.Entities.SprintBacklog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("SprintBacklog");
                });

            modelBuilder.Entity("App.DAL.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssigneeId");

                    b.Property<int>("BacklogTaskId");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int>("ColumnId");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("HistoryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("BacklogTaskId");

                    b.HasIndex("ColumnId");

                    b.HasIndex("HistoryId");

                    b.ToTable("Tasks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Task");
                });

            modelBuilder.Entity("App.DAL.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("App.DAL.Entities.Teams2Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MemberId");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TeamId");

                    b.ToTable("Teams2Users");
                });

            modelBuilder.Entity("App.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Fullname")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.DAL.Entities.KanbanBoard", b =>
                {
                    b.HasBaseType("App.DAL.Entities.BoardBase");

                    b.ToTable("KanbanBoards");

                    b.HasDiscriminator().HasValue("KanbanBoard");
                });

            modelBuilder.Entity("App.DAL.Entities.ScrumBoard", b =>
                {
                    b.HasBaseType("App.DAL.Entities.BoardBase");

                    b.Property<int>("CurrentSprintId");

                    b.HasIndex("CurrentSprintId")
                        .IsUnique();

                    b.ToTable("ScrumBoards");

                    b.HasDiscriminator().HasValue("ScrumBoard");
                });

            modelBuilder.Entity("App.DAL.Entities.KanbanTask", b =>
                {
                    b.HasBaseType("App.DAL.Entities.Task");

                    b.Property<int>("StoryPointsSpent");

                    b.ToTable("KanbanTasks");

                    b.HasDiscriminator().HasValue("KanbanTask");
                });

            modelBuilder.Entity("App.DAL.Entities.ScrumTask", b =>
                {
                    b.HasBaseType("App.DAL.Entities.Task");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<int>("SprintId");

                    b.Property<int>("StoryPointsExpected");

                    b.Property<int>("StoryPointsSpent")
                        .HasColumnName("ScrumTask_StoryPointsSpent");

                    b.HasIndex("SprintId");

                    b.ToTable("ScrumTasks");

                    b.HasDiscriminator().HasValue("ScrumTask");
                });

            modelBuilder.Entity("App.DAL.Entities.BacklogTask", b =>
                {
                    b.HasOne("App.DAL.Entities.ProjectBacklog")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectBacklogId");

                    b.HasOne("App.DAL.Entities.Requirement", "Requirement")
                        .WithMany("Tasks")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.SprintBacklog")
                        .WithMany("Tasks")
                        .HasForeignKey("SprintBacklogId");
                });

            modelBuilder.Entity("App.DAL.Entities.BoardBase", b =>
                {
                    b.HasOne("App.DAL.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Column", b =>
                {
                    b.HasOne("App.DAL.Entities.BoardBase", "Board")
                        .WithMany("Columns")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Comment", b =>
                {
                    b.HasOne("App.DAL.Entities.Attachment", "Attachments")
                        .WithMany()
                        .HasForeignKey("AttachmentsId");

                    b.HasOne("App.DAL.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.Task", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.ConstraintRecord", b =>
                {
                    b.HasOne("App.DAL.Entities.BoardBase")
                        .WithMany("Constraints")
                        .HasForeignKey("BoardBaseId");

                    b.HasOne("App.DAL.Entities.Column")
                        .WithMany("Constraints")
                        .HasForeignKey("ColumnId");

                    b.HasOne("App.DAL.Entities.Task", "Task")
                        .WithMany("Constraints")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("App.DAL.Entities.ContactInfo", b =>
                {
                    b.HasOne("App.DAL.Entities.User", "Owner")
                        .WithMany("Contacts")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("App.DAL.Entities.Cooperation", b =>
                {
                    b.HasOne("App.DAL.Entities.Company", "Company")
                        .WithMany("Cooperations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.User", "Member")
                        .WithMany("CompanyCooperations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.HistoryPoint", b =>
                {
                    b.HasOne("App.DAL.Entities.History", "History")
                        .WithMany("Events")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Label", b =>
                {
                    b.HasOne("App.DAL.Entities.BoardBase", "Board")
                        .WithMany("Labels")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.Task")
                        .WithMany("Labels")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("App.DAL.Entities.Project", b =>
                {
                    b.HasOne("App.DAL.Entities.ProjectBacklog", "Backlog")
                        .WithOne("Project")
                        .HasForeignKey("App.DAL.Entities.Project", "BacklogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.User", "ProjectRoot")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectRootId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.RequirementICollection", "RequirementICollection")
                        .WithOne("Project")
                        .HasForeignKey("App.DAL.Entities.Project", "RequirementICollectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Requirement", b =>
                {
                    b.HasOne("App.DAL.Entities.RequirementICollection", "RequirementICollection")
                        .WithMany("Requirements")
                        .HasForeignKey("RequirementICollectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Sprint", b =>
                {
                    b.HasOne("App.DAL.Entities.SprintBacklog", "Backlog")
                        .WithOne("Sprint")
                        .HasForeignKey("App.DAL.Entities.Sprint", "SprintBacklogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Task", b =>
                {
                    b.HasOne("App.DAL.Entities.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.BacklogTask", "BacklogTask")
                        .WithMany()
                        .HasForeignKey("BacklogTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.Column", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.History", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Team", b =>
                {
                    b.HasOne("App.DAL.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.Project", "Project")
                        .WithMany("Teams")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.Teams2Users", b =>
                {
                    b.HasOne("App.DAL.Entities.User", "Member")
                        .WithMany("TeamUserPairs")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.DAL.Entities.Team", "Team")
                        .WithMany("TeamUserPairs")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.ScrumBoard", b =>
                {
                    b.HasOne("App.DAL.Entities.Sprint", "CurrentSprint")
                        .WithOne("Board")
                        .HasForeignKey("App.DAL.Entities.ScrumBoard", "CurrentSprintId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.DAL.Entities.ScrumTask", b =>
                {
                    b.HasOne("App.DAL.Entities.Sprint", "Sprint")
                        .WithMany()
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
