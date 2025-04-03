using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaTasks.Migrations
{
    /// <inheritdoc />
    public partial class CriarPrototipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AssignedUserId",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_AssignedUserId",
                table: "Tarefas",
                column: "AssignedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_AspNetUsers_AssignedUserId",
                table: "Tarefas",
                column: "AssignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_AspNetUsers_AssignedUserId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_AssignedUserId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedUserId",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
