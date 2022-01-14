using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assicurazione.Migrations
{
    public partial class secondaMigrazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodiceFiscaleID = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodiceFiscaleID);
                });

            migrationBuilder.CreateTable(
                name: "Polizza",
                columns: table => new
                {
                    NumeroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStipula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportoAssicurato = table.Column<float>(type: "real", nullable: false),
                    RataMensile = table.Column<float>(type: "real", nullable: false),
                    CodiceFiscaleID = table.Column<string>(type: "nchar(16)", nullable: false),
                    polizza_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentualeCoperta = table.Column<int>(type: "int", nullable: true),
                    Targa = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Cilindrata = table.Column<int>(type: "int", nullable: true),
                    AnniDelAssicurato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizza", x => x.NumeroID);
                    table.ForeignKey(
                        name: "Fk_Cliente",
                        column: x => x.CodiceFiscaleID,
                        principalTable: "Cliente",
                        principalColumn: "CodiceFiscaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizza_CodiceFiscaleID",
                table: "Polizza",
                column: "CodiceFiscaleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizza");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
