using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHive.API.Migrations
{
    /// <inheritdoc />
    public partial class initailCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project_Tracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project_Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Project_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Project_Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Arrival_Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Arrival_Source_IG = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Customer_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customer_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Arrival_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Questions_Submission_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Questions_Response_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Submission_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Client_Presentation_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    DealDecision_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Expected_Project_Start_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Closure_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Revenue_Start_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Solution_Architect = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Up_Or_Cross_Sell = table.Column<bool>(type: "bit", nullable: true),
                    Up_Or_Cross_Selling_Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Prior_Practice_Experience_With_Customer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Reason_For_Not_Proposing_Tools = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Deal_TCV = table.Column<float>(type: "real", nullable: false),
                    Deal_PAT = table.Column<float>(type: "real", nullable: false),
                    Win_Probability = table.Column<int>(type: "int", nullable: false),
                    Overall_Team_Size = table.Column<int>(type: "int", nullable: false),
                    Total_Team_Size = table.Column<int>(type: "int", nullable: false),
                    Mail_List = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Updated_By = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Tracker", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project_Tracker");
        }
    }
}
