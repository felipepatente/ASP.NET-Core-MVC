using Microsoft.EntityFrameworkCore.Migrations;

namespace EnsinoSuperior.Migrations
{
    public partial class AdicionandoClasseAcademico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoID",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Instituicoes_InstituicaoID",
                table: "Departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos");

            migrationBuilder.RenameTable(
                name: "Departamentos",
                newName: "Departamento");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_InstituicaoID",
                table: "Departamento",
                newName: "IX_Departamento_InstituicaoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Departamento_DepartamentoID",
                table: "Cursos",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Cursos_Departamento_DepartamentoID",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Instituicoes_InstituicaoID",
                table: "Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.RenameTable(
                name: "Departamento",
                newName: "Departamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Departamento_InstituicaoID",
                table: "Departamentos",
                newName: "IX_Departamentos_InstituicaoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoID",
                table: "Cursos",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Instituicoes_InstituicaoID",
                table: "Departamentos",
                column: "InstituicaoID",
                principalTable: "Instituicoes",
                principalColumn: "InstituicaoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
