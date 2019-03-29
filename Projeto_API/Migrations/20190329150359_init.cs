using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DataNasc = table.Column<string>(nullable: true),
                    CargoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Gerente" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Vendedor" });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Entregador" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "CargoId", "DataNasc", "Nome", "Sobrenome" },
                values: new object[] { 1, 1, "01/01/2000", "Maria", "Silva" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "CargoId", "DataNasc", "Nome", "Sobrenome" },
                values: new object[] { 2, 2, "02/02/2000", "João", "Souza" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "CargoId", "DataNasc", "Nome", "Sobrenome" },
                values: new object[] { 3, 3, "03/03/2000", "José", "Oliveira" });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
