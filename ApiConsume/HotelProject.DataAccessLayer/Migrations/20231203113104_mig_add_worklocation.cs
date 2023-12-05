using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_worklocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkDepartment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorklocationID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkLocations",
                columns: table => new
                {
                    WorklocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLocationCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocations", x => x.WorklocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorklocationID",
                table: "AspNetUsers",
                column: "WorklocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorklocationID",
                table: "AspNetUsers",
                column: "WorklocationID",
                principalTable: "WorkLocations",
                principalColumn: "WorklocationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorklocationID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorklocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkDepartment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorklocationID",
                table: "AspNetUsers");
        }
    }
}
