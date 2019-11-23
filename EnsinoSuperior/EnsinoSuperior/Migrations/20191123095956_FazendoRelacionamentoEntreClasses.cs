using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsinoSuperior.Migrations
{
    public partial class FazendoRelacionamentoEntreClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InstituicaoID",
                table: "Departamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_InstituicaoID",
                table: "Departamento",
                column: "InstituicaoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Instituicoes_InstituicaoID",
                table: "Departamento",
                column: "InstituicaoID",
                principalTable: "Instituicoes",
                principalColumn: "InstituicaoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Instituicoes_InstituicaoID",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_InstituicaoID",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "InstituicaoID",
                table: "Departamento");
        }
    }
}
