using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class FistMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DadosGraficosAnuais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdmittedCount = table.Column<int>(type: "int", nullable: false),
                    TerminatedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosGraficosAnuais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Rua = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LabeledValue<double>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Value = table.Column<double>(type: "double", nullable: false),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DadosGraficoAnualId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DadosGraficoAnualId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DadosGraficoAnualId2 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DadosGraficoAnualId3 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DadosGraficoAnualId4 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabeledValue<double>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabeledValue<double>_DadosGraficosAnuais_DadosGraficoAnualId",
                        column: x => x.DadosGraficoAnualId,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabeledValue<double>_DadosGraficosAnuais_DadosGraficoAnualId1",
                        column: x => x.DadosGraficoAnualId1,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabeledValue<double>_DadosGraficosAnuais_DadosGraficoAnualId2",
                        column: x => x.DadosGraficoAnualId2,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabeledValue<double>_DadosGraficosAnuais_DadosGraficoAnualId3",
                        column: x => x.DadosGraficoAnualId3,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabeledValue<double>_DadosGraficosAnuais_DadosGraficoAnualId4",
                        column: x => x.DadosGraficoAnualId4,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LabeledValue<string>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DadosGraficoAnualId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DadosGraficoAnualId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabeledValue<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabeledValue<string>_DadosGraficosAnuais_DadosGraficoAnualId",
                        column: x => x.DadosGraficoAnualId,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabeledValue<string>_DadosGraficosAnuais_DadosGraficoAnualId1",
                        column: x => x.DadosGraficoAnualId1,
                        principalTable: "DadosGraficosAnuais",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNasci = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAdmi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDemi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SetorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EnderecoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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
                    table.ForeignKey(
                        name: "FK_Funcionarios_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Acompanhamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Produtividade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Qualidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prazos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comunicacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TrabalhoEquipe = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Adaptabilidade = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Proatividade = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Feedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Treinamento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Plano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avaliador = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Confirmacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompanhamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acompanhamentos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Desligamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataDesligamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isGrave = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FeedDesligamento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desligamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desligamentos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FitCulturals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitCulturals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitCulturals_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MotivoDesligamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Motivo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DesligamentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoDesligamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotivoDesligamentos_Desligamentos_DesligamentoId",
                        column: x => x.DesligamentoId,
                        principalTable: "Desligamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotivoDesligamentos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_FuncionarioId",
                table: "Acompanhamentos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Desligamentos_FuncionarioId",
                table: "Desligamentos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FitCulturals_FuncionarioId",
                table: "FitCulturals",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SetorId",
                table: "Funcionarios",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<double>_DadosGraficoAnualId",
                table: "LabeledValue<double>",
                column: "DadosGraficoAnualId");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<double>_DadosGraficoAnualId1",
                table: "LabeledValue<double>",
                column: "DadosGraficoAnualId1");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<double>_DadosGraficoAnualId2",
                table: "LabeledValue<double>",
                column: "DadosGraficoAnualId2");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<double>_DadosGraficoAnualId3",
                table: "LabeledValue<double>",
                column: "DadosGraficoAnualId3");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<double>_DadosGraficoAnualId4",
                table: "LabeledValue<double>",
                column: "DadosGraficoAnualId4");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<string>_DadosGraficoAnualId",
                table: "LabeledValue<string>",
                column: "DadosGraficoAnualId");

            migrationBuilder.CreateIndex(
                name: "IX_LabeledValue<string>_DadosGraficoAnualId1",
                table: "LabeledValue<string>",
                column: "DadosGraficoAnualId1");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoDesligamentos_DesligamentoId",
                table: "MotivoDesligamentos",
                column: "DesligamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoDesligamentos_FuncionarioId",
                table: "MotivoDesligamentos",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acompanhamentos");

            migrationBuilder.DropTable(
                name: "FitCulturals");

            migrationBuilder.DropTable(
                name: "LabeledValue<double>");

            migrationBuilder.DropTable(
                name: "LabeledValue<string>");

            migrationBuilder.DropTable(
                name: "MotivoDesligamentos");

            migrationBuilder.DropTable(
                name: "DadosGraficosAnuais");

            migrationBuilder.DropTable(
                name: "Desligamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
