using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigo.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultoriaAcessoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(200)", nullable: false),
                    Periodo = table.Column<int>(nullable: false),
                    Setor = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    TipoDepartamento = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    IdTipoNormaExterna = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultoriaAcessoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NormaInterna",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoNorma = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Autor = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormaInterna", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultoriaAcessoria");

            migrationBuilder.DropTable(
                name: "NormaInterna");
        }
    }
}
