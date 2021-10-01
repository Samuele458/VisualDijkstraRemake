using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class usersCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graphs_Users_UserId",
                table: "Graphs");

            migrationBuilder.AddForeignKey(
                name: "FK_Graphs_Users_UserId",
                table: "Graphs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graphs_Users_UserId",
                table: "Graphs");

            migrationBuilder.AddForeignKey(
                name: "FK_Graphs_Users_UserId",
                table: "Graphs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
