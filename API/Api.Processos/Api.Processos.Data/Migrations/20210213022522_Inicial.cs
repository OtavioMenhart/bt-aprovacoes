using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Processos.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Processos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroProcesso = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    ValorCausa = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Escritorio = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    NomeReclamante = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime", nullable: true),
                    FlgAtivo = table.Column<bool>(nullable: false),
                    FlgAprovado = table.Column<bool>(nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Processos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UC_NumeroProcesso",
                table: "Tbl_Processos",
                column: "NumeroProcesso",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Processos");
        }
    }
}
