using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Migrations
{
    public partial class AvaliacaoLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_AspNetUsers_IdUsuario",
                table: "Avaliacao");

            migrationBuilder.UpdateData(
                table: "Avaliacao",
                keyColumn: "IdUsuario",
                keyValue: null,
                column: "IdUsuario",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Avaliacao",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_AspNetUsers_IdUsuario",
                table: "Avaliacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_AspNetUsers_IdUsuario",
                table: "Avaliacao");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Avaliacao",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_AspNetUsers_IdUsuario",
                table: "Avaliacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
