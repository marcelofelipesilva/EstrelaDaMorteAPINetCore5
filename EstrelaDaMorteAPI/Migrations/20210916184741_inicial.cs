using Microsoft.EntityFrameworkCore.Migrations;

namespace EstrelaDaMorteAPI.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PLANETA",
                columns: table => new
                {
                    IdPlaneta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rotacao = table.Column<double>(type: "float", nullable: false),
                    Orbita = table.Column<double>(type: "float", nullable: false),
                    Diametro = table.Column<double>(type: "float", nullable: false),
                    Clima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Populacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANETA", x => x.IdPlaneta);
                });

            migrationBuilder.CreateTable(
                name: "TB_PILOTO",
                columns: table => new
                {
                    IdPiloto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPlaneta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PILOTO", x => x.IdPiloto);
                    table.ForeignKey(
                        name: "FK_TB_PILOTO_TB_PLANETA_IdPlaneta",
                        column: x => x.IdPlaneta,
                        principalTable: "TB_PLANETA",
                        principalColumn: "IdPlaneta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_NAVE",
                columns: table => new
                {
                    IdNave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passageiros = table.Column<int>(type: "int", nullable: false),
                    Carga = table.Column<double>(type: "float", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PilotoIdPiloto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NAVE", x => x.IdNave);
                    table.ForeignKey(
                        name: "FK_TB_NAVE_TB_PILOTO_PilotoIdPiloto",
                        column: x => x.PilotoIdPiloto,
                        principalTable: "TB_PILOTO",
                        principalColumn: "IdPiloto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_NAVE_PilotoIdPiloto",
                table: "TB_NAVE",
                column: "PilotoIdPiloto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PILOTO_IdPlaneta",
                table: "TB_PILOTO",
                column: "IdPlaneta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_NAVE");

            migrationBuilder.DropTable(
                name: "TB_PILOTO");

            migrationBuilder.DropTable(
                name: "TB_PLANETA");
        }
    }
}
