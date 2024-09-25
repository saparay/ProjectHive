using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHive.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountVerticalStatusId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Tracker_Account_List_AccountListId",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_AccountListId",
                table: "Project_Tracker");

            migrationBuilder.RenameColumn(
                name: "AccountListId",
                table: "Project_Tracker",
                newName: "Account_List_Id");

            migrationBuilder.AddColumn<int>(
                name: "Status_List_Id",
                table: "Project_Tracker",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vertical_List_Id",
                table: "Project_Tracker",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status_List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vertical_List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertical_List", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Tracker_Account_List_Account_List_Id",
                table: "Project_Tracker",
                column: "Account_List_Id",
                principalTable: "Account_List",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Tracker_Status_List_Status_List_Id",
                table: "Project_Tracker",
                column: "Status_List_Id",
                principalTable: "Status_List",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Tracker_Vertical_List_Vertical_List_Id",
                table: "Project_Tracker",
                column: "Vertical_List_Id",
                principalTable: "Vertical_List",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Tracker_Account_List_Account_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Tracker_Status_List_Status_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Tracker_Vertical_List_Vertical_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropTable(
                name: "Status_List");

            migrationBuilder.DropTable(
                name: "Vertical_List");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Account_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Status_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropIndex(
                name: "IX_Project_Tracker_Vertical_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropColumn(
                name: "Status_List_Id",
                table: "Project_Tracker");

            migrationBuilder.DropColumn(
                name: "Vertical_List_Id",
                table: "Project_Tracker");

            migrationBuilder.RenameColumn(
                name: "Account_List_Id",
                table: "Project_Tracker",
                newName: "AccountListId");

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
    }
}
