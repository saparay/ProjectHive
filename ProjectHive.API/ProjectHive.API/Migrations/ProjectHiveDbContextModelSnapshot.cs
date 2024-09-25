﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectHive.API.Data;

#nullable disable

namespace ProjectHive.API.Migrations
{
    [DbContext(typeof(ProjectHiveDbContext))]
    partial class ProjectHiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeographyLocationProjectTracker", b =>
                {
                    b.Property<int>("GeographyLocationsId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectTrackersId")
                        .HasColumnType("int");

                    b.HasKey("GeographyLocationsId", "ProjectTrackersId");

                    b.HasIndex("ProjectTrackersId");

                    b.ToTable("GeographyLocationProjectTracker");
                });

            modelBuilder.Entity("ProjectHive.API.Models.AccountList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Account_List");
                });

            modelBuilder.Entity("ProjectHive.API.Models.GeographyLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Geography_Location");
                });

            modelBuilder.Entity("ProjectHive.API.Models.ProjectTracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountListId")
                        .HasColumnType("int")
                        .HasColumnName("Account_List_Id");

                    b.Property<DateOnly?>("ArrivalDate")
                        .HasColumnType("date")
                        .HasColumnName("Arrival_Date");

                    b.Property<string>("ArrivalSource")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Arrival_Source");

                    b.Property<string>("ArrivalSourceIG")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("Arrival_Source_IG");

                    b.Property<DateOnly?>("ClientPresentationDate")
                        .HasColumnType("date")
                        .HasColumnName("Client_Presentation_Date");

                    b.Property<DateOnly?>("ClosureDate")
                        .HasColumnType("date")
                        .HasColumnName("Closure_Date");

                    b.Property<string>("Comments")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Comments");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Created_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_Date");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Customer_Email");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Customer_Name");

                    b.Property<DateOnly?>("DealDecisionDate")
                        .HasColumnType("date")
                        .HasColumnName("DealDecision_Date");

                    b.Property<float?>("DealPAT")
                        .HasColumnType("real")
                        .HasColumnName("Deal_PAT");

                    b.Property<float?>("DealTCV")
                        .HasColumnType("real")
                        .HasColumnName("Deal_TCV");

                    b.Property<DateOnly?>("ExpectedProjectStartDate")
                        .HasColumnType("date")
                        .HasColumnName("Expected_Project_Start_Date");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Last_Updated_By");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Last_Updated_Date");

                    b.Property<string>("MailList")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Mail_List");

                    b.Property<int?>("OverallTeamSize")
                        .HasColumnType("int")
                        .HasColumnName("Overall_Team_Size");

                    b.Property<string>("PriorPracticeExperienceWithCustomer")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Prior_Practice_Experience_With_Customer");

                    b.Property<string>("ProjectDescription")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Project_Description");

                    b.Property<string>("ProjectId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Project_Id");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Project_Name");

                    b.Property<DateOnly?>("QuestionsResponseDate")
                        .HasColumnType("date")
                        .HasColumnName("Questions_Response_Date");

                    b.Property<DateOnly?>("QuestionsSubmissionDate")
                        .HasColumnType("date")
                        .HasColumnName("Questions_Submission_Date");

                    b.Property<string>("ResonForNotProposingTools")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Reason_For_Not_Proposing_Tools");

                    b.Property<DateOnly?>("RevenueStartDate")
                        .HasColumnType("date")
                        .HasColumnName("Revenue_Start_Date");

                    b.Property<string>("SolutionArchitect")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Solution_Architect");

                    b.Property<int?>("StatusListId")
                        .HasColumnType("int")
                        .HasColumnName("Status_List_Id");

                    b.Property<DateOnly?>("SubmissionDate")
                        .HasColumnType("date")
                        .HasColumnName("Submission_Date");

                    b.Property<int?>("TotalTeamSize")
                        .HasColumnType("int")
                        .HasColumnName("Total_Team_Size");

                    b.Property<bool?>("UpOrCrossSell")
                        .HasColumnType("bit")
                        .HasColumnName("Up_Or_Cross_Sell");

                    b.Property<string>("UpOrCrossSellingDescription")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Up_Or_Cross_Selling_Description");

                    b.Property<int?>("VerticalListId")
                        .HasColumnType("int")
                        .HasColumnName("Vertical_List_Id");

                    b.Property<int?>("WinProbability")
                        .HasColumnType("int")
                        .HasColumnName("Win_Probability");

                    b.HasKey("Id");

                    b.HasIndex("AccountListId");

                    b.HasIndex("StatusListId");

                    b.HasIndex("VerticalListId");

                    b.ToTable("Project_Tracker");
                });

            modelBuilder.Entity("ProjectHive.API.Models.StatusList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status_List");
                });

            modelBuilder.Entity("ProjectHive.API.Models.VerticalList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Vertical_List");
                });

            modelBuilder.Entity("GeographyLocationProjectTracker", b =>
                {
                    b.HasOne("ProjectHive.API.Models.GeographyLocation", null)
                        .WithMany()
                        .HasForeignKey("GeographyLocationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHive.API.Models.ProjectTracker", null)
                        .WithMany()
                        .HasForeignKey("ProjectTrackersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectHive.API.Models.ProjectTracker", b =>
                {
                    b.HasOne("ProjectHive.API.Models.AccountList", "AccountList")
                        .WithMany("ProjectTracker")
                        .HasForeignKey("AccountListId");

                    b.HasOne("ProjectHive.API.Models.StatusList", "StatusList")
                        .WithMany("ProjectTracker")
                        .HasForeignKey("StatusListId");

                    b.HasOne("ProjectHive.API.Models.VerticalList", "VerticalList")
                        .WithMany("ProjectTracker")
                        .HasForeignKey("VerticalListId");

                    b.Navigation("AccountList");

                    b.Navigation("StatusList");

                    b.Navigation("VerticalList");
                });

            modelBuilder.Entity("ProjectHive.API.Models.AccountList", b =>
                {
                    b.Navigation("ProjectTracker");
                });

            modelBuilder.Entity("ProjectHive.API.Models.StatusList", b =>
                {
                    b.Navigation("ProjectTracker");
                });

            modelBuilder.Entity("ProjectHive.API.Models.VerticalList", b =>
                {
                    b.Navigation("ProjectTracker");
                });
#pragma warning restore 612, 618
        }
    }
}
