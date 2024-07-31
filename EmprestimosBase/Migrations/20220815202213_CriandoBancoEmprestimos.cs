using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosBase.Migrations
{
    public partial class CriandoBancoEmprestimos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:Identity", "1, 1"),

                    Recebedor = table.Column<string>(type: "varchar", nullable: false),
                    Fornecedor = table.Column<string>(type: "varchar", nullable: false),
                    LivroEmprestado = table.Column<string>(type: "varchar", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");
        }
    }
}
