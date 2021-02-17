using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Processos.Data.Migrations
{
    public partial class AlteracoesTabelaProcessos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Processos",
                table: "Tbl_Processos");

            migrationBuilder.RenameTable(
                name: "Tbl_Processos",
                newName: "Processo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processo",
                table: "Processo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Processo",
                table: "Processo");

            migrationBuilder.RenameTable(
                name: "Processo",
                newName: "Tbl_Processos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Processos",
                table: "Tbl_Processos",
                column: "Id");
        }
    }
}
