using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHive.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAcccountListIdToProjectTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountListId",
                table: "Project_Tracker",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Account_List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_List", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_AccountListId",
                table: "Project_Tracker",
                column: "AccountListId",
                unique: true,
                filter: "[AccountListId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Tracker_Account_List_AccountListId",
                table: "Project_Tracker",
                column: "AccountListId",
                principalTable: "Account_List",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Tracker_Account_List_AccountListId",
                table: "Project_Tracker");

            migrationBuilder.DropTable(
                name: "Account_List");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_AccountListId",
                table: "Project_Tracker");

            migrationBuilder.DropColumn(
                name: "AccountListId",
                table: "Project_Tracker");
        }
    }
}
