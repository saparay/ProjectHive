using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHive.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyToManyRelBtnProjectTrackerAndGeography : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geography_Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geography_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeographyLocationProjectTracker",
                columns: table => new
                {
                    GeographyLocationsId = table.Column<int>(type: "int", nullable: false),
                    ProjectTrackersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographyLocationProjectTracker", x => new { x.GeographyLocationsId, x.ProjectTrackersId });
                    table.ForeignKey(
                        name: "FK_GeographyLocationProjectTracker_Geography_Location_GeographyLocationsId",
                        column: x => x.GeographyLocationsId,
                        principalTable: "Geography_Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeographyLocationProjectTracker_Project_Tracker_ProjectTrackersId",
                        column: x => x.ProjectTrackersId,
                        principalTable: "Project_Tracker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeographyLocationProjectTracker_ProjectTrackersId",
                table: "GeographyLocationProjectTracker",
                column: "ProjectTrackersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeographyLocationProjectTracker");

            migrationBuilder.DropTable(
                name: "Geography_Location");
        }
    }
}
