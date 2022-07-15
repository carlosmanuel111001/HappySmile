using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appClinica.Adapters.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUsuarios",
                columns: table => new
                {
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bandera = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuarios", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "tblEspecialistas",
                columns: table => new
                {
                    especialistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bandera = table.Column<bool>(type: "bit", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEspecialistas", x => x.especialistaId);
                    table.ForeignKey(
                        name: "FK_tblEspecialistas_tblUsuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "tblUsuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPacientes",
                columns: table => new
                {
                    pacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bandera = table.Column<bool>(type: "bit", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPacientes", x => x.pacienteId);
                    table.ForeignKey(
                        name: "FK_tblPacientes_tblUsuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "tblUsuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCitas",
                columns: table => new
                {
                    citaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especialistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCitas", x => x.citaId);
                    table.ForeignKey(
                        name: "FK_tblCitas_tblPacientes_pacienteId",
                        column: x => x.pacienteId,
                        principalTable: "tblPacientes",
                        principalColumn: "pacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDiagnosticos",
                columns: table => new
                {
                    especialistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    citaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaDiagnostico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcionMalestar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcionDiagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadoDiagnostico = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiagnosticos", x => new { x.especialistaId, x.citaId });
                    table.ForeignKey(
                        name: "FK_tblDiagnosticos_tblCitas_citaId",
                        column: x => x.citaId,
                        principalTable: "tblCitas",
                        principalColumn: "citaId");
                    table.ForeignKey(
                        name: "FK_tblDiagnosticos_tblEspecialistas_especialistaId",
                        column: x => x.especialistaId,
                        principalTable: "tblEspecialistas",
                        principalColumn: "especialistaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCitas_pacienteId",
                table: "tblCitas",
                column: "pacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDiagnosticos_citaId",
                table: "tblDiagnosticos",
                column: "citaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEspecialistas_usuarioId",
                table: "tblEspecialistas",
                column: "usuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblPacientes_usuarioId",
                table: "tblPacientes",
                column: "usuarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDiagnosticos");

            migrationBuilder.DropTable(
                name: "tblCitas");

            migrationBuilder.DropTable(
                name: "tblEspecialistas");

            migrationBuilder.DropTable(
                name: "tblPacientes");

            migrationBuilder.DropTable(
                name: "tblUsuarios");
        }
    }
}
