using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class References : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Graphs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Graphs_UserId",
                table: "Graphs",
                column: "UserId");

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

            migrationBuilder.DropIndex(
                name: "IX_Graphs_UserId",
                table: "Graphs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Graphs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
