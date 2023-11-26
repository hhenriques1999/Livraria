using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Migrations
{
    public partial class MudancasCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Carrinho_CarrinhoId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "ItensCarrinho");

            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_CarrinhoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdCarrinho",
                table: "Pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCarrinho",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItensCarrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCarrinho = table.Column<int>(type: "int", nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Carrinho_IdCarrinho",
                        column: x => x.IdCarrinho,
                        principalTable: "Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Livros_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CarrinhoId",
                table: "Pedido",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinho_IdCarrinho",
                table: "ItensCarrinho",
                column: "IdCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinho_IdLivro",
                table: "ItensCarrinho",
                column: "IdLivro");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Carrinho_CarrinhoId",
                table: "Pedido",
                column: "CarrinhoId",
                principalTable: "Carrinho",
                principalColumn: "Id");
        }
    }
}
