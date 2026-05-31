using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica_y_transporte.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_Cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "varchar(150)", nullable: true),
                    nit = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    id_ruta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zona = table.Column<string>(type: "varchar(100)", nullable: false),
                    piloto = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.id_ruta);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    ID_paquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.ID_paquete);
                    table.ForeignKey(
                        name: "FK_Paquetes_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    id_envio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_paquete = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    id_ruta = table.Column<int>(type: "int", nullable: true),
                    fecha_envio = table.Column<DateTime>(type: "date", nullable: false),
                    estado = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.id_envio);
                    table.ForeignKey(
                        name: "FK_Envios_Paquetes_id_paquete",
                        column: x => x.id_paquete,
                        principalTable: "Paquetes",
                        principalColumn: "ID_paquete",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Envios_Rutas_id_ruta",
                        column: x => x.id_ruta,
                        principalTable: "Rutas",
                        principalColumn: "id_ruta",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id_factura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_envio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechas = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id_factura);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_Envios_id_envio",
                        column: x => x.id_envio,
                        principalTable: "Envios",
                        principalColumn: "id_envio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envios_id_paquete",
                table: "Envios",
                column: "id_paquete");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_id_ruta",
                table: "Envios",
                column: "id_ruta");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_id_cliente",
                table: "Facturas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_id_envio",
                table: "Facturas",
                column: "id_envio");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_id_cliente",
                table: "Paquetes",
                column: "id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
