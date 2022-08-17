using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PI_DigitalHouse_API_MVC.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcheiPet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TipoPet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informações = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumColeira = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcheiPet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadastroUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    StatusCadastro = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadastroPets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informações = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raça = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroPets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CadastroPets_CadastroUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CadastroUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerdiMeusPets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Informacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalDesaparecimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPerdido = table.Column<bool>(type: "bit", nullable: false),
                    CadastroPetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerdiMeusPets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerdiMeusPets_CadastroPets_CadastroPetId",
                        column: x => x.CadastroPetId,
                        principalTable: "CadastroPets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadastroPets_UsuarioId",
                table: "CadastroPets",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerdiMeusPets_CadastroPetId",
                table: "PerdiMeusPets",
                column: "CadastroPetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcheiPet");

            migrationBuilder.DropTable(
                name: "PerdiMeusPets");

            migrationBuilder.DropTable(
                name: "CadastroPets");

            migrationBuilder.DropTable(
                name: "CadastroUsuarios");
        }
    }
}
