﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelSF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorizacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ObservacaoFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGerente1 = table.Column<long>(type: "bigint", nullable: false),
                    ObservacaoGerente1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusGerente1 = table.Column<bool>(type: "bit", nullable: false),
                    IdGerente2 = table.Column<long>(type: "bigint", nullable: false),
                    ObservacaoGerente2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusGerente2 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Longadouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCasa = table.Column<long>(type: "bigint", nullable: false),
                    CEP = table.Column<long>(type: "bigint", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    QuantidadeDeDias = table.Column<long>(type: "bigint", nullable: false),
                    Venda = table.Column<bool>(type: "bit", nullable: false),
                    UltimoPeriodo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoAquisitivo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    DataDaContratacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimoPeriodo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoAquisitivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    CargoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ferias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    AutorizacaoId = table.Column<long>(type: "bigint", nullable: true),
                    AdiantamentoDecimoTerceiro = table.Column<bool>(type: "bit", nullable: false),
                    HistoricoId = table.Column<long>(type: "bigint", nullable: true),
                    DataInicio2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorizacaoGerente1 = table.Column<bool>(type: "bit", nullable: false),
                    AutorizacaoGerente2 = table.Column<bool>(type: "bit", nullable: false),
                    PeriodoAquisitivoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ferias_Autorizacao_AutorizacaoId",
                        column: x => x.AutorizacaoId,
                        principalTable: "Autorizacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ferias_Historico_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ferias_PeriodoAquisitivo_PeriodoAquisitivoId",
                        column: x => x.PeriodoAquisitivoId,
                        principalTable: "PeriodoAquisitivo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CPF = table.Column<long>(type: "bigint", nullable: false),
                    TelefoneId = table.Column<long>(type: "bigint", nullable: true),
                    FeriasId = table.Column<long>(type: "bigint", nullable: true),
                    ContratoId = table.Column<long>(type: "bigint", nullable: true),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionario_Ferias_FeriasId",
                        column: x => x.FeriasId,
                        principalTable: "Ferias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionario_Telefone_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "Telefone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_CargoId",
                table: "Contrato",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_AutorizacaoId",
                table: "Ferias",
                column: "AutorizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_HistoricoId",
                table: "Ferias",
                column: "HistoricoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_PeriodoAquisitivoId",
                table: "Ferias",
                column: "PeriodoAquisitivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_ContratoId",
                table: "Funcionario",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_FeriasId",
                table: "Funcionario",
                column: "FeriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_TelefoneId",
                table: "Funcionario",
                column: "TelefoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Ferias");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Autorizacao");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "PeriodoAquisitivo");
        }
    }
}
