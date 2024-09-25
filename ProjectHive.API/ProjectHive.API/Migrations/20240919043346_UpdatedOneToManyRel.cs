using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHive.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOneToManyRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Account_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Status_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Vertical_List_Id",
                table: "Project_Tracker");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_Account_List_Id",
                table: "Project_Tracker",
                column: "Account_List_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_Status_List_Id",
                table: "Project_Tracker",
                column: "Status_List_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_Vertical_List_Id",
                table: "Project_Tracker",
                column: "Vertical_List_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Account_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Status_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Vertical_List_Id",
                table: "Project_Tracker");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_Account_List_Id",
                table: "Project_Tracker",
                column: "Account_List_Id",
                unique: true,
                filter: "[Account_List_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_Status_List_Id",
                table: "Project_Tracker",
                column: "Status_List_Id",
                unique: true,
                filter: "[Status_List_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_Vertical_List_Id",
                table: "Project_Tracker",
                column: "Vertical_List_Id",
                unique: true,
                filter: "[Vertical_List_Id] IS NOT NULL");
        }
    }
}
