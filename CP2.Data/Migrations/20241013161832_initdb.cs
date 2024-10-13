using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2.Data.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    DataContratacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ComissaoPercentual = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MetaMensal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendedor", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_fornecedor");

            migrationBuilder.DropTable(
                name: "tb_vendedor");
        }
    }
}
