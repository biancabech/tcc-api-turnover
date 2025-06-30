using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acompanhamentos_Funcionario_Funcionarioid",
                table: "Acompanhamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Desligamentos_Funcionario_Funcionarioid",
                table: "Desligamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Desligamentos_Funcionario_funcionarioid",
                table: "Desligamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_FitCulturals_Funcionario_Funcionarioid",
                table: "FitCulturals");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Funcionario_Funcionarioid",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_MotivoDesligamentos_Funcionario_Funcionarioid",
                table: "MotivoDesligamentos");

            migrationBuilder.DropIndex(
                name: "IX_Desligamentos_Funcionarioid",
                table: "Desligamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_Funcionarioid",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Funcionarioid",
                table: "Desligamentos");

            migrationBuilder.DropColumn(
                name: "Funcionarioid",
                table: "Funcionario");

            migrationBuilder.RenameTable(
                name: "Funcionario",
                newName: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "Funcionarioid",
                table: "MotivoDesligamentos",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_MotivoDesligamentos_Funcionarioid",
                table: "MotivoDesligamentos",
                newName: "IX_MotivoDesligamentos_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "Funcionarioid",
                table: "FitCulturals",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_FitCulturals_Funcionarioid",
                table: "FitCulturals",
                newName: "IX_FitCulturals_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "funcionarioid",
                table: "Desligamentos",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Desligamentos_funcionarioid",
                table: "Desligamentos",
                newName: "IX_Desligamentos_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "Funcionarioid",
                table: "Acompanhamentos",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Acompanhamentos_Funcionarioid",
                table: "Acompanhamentos",
                newName: "IX_Acompanhamentos_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Funcionarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Funcionarios",
                newName: "Email");

            migrationBuilder.AddColumn<Guid>(
                name: "CargoId",
                table: "Funcionarios",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acompanhamentos_Funcionarios_FuncionarioId",
                table: "Acompanhamentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Desligamentos_Funcionarios_FuncionarioId",
                table: "Desligamentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitCulturals_Funcionarios_FuncionarioId",
                table: "FitCulturals",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cargos_CargoId",
                table: "Funcionarios",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotivoDesligamentos_Funcionarios_FuncionarioId",
                table: "MotivoDesligamentos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acompanhamentos_Funcionarios_FuncionarioId",
                table: "Acompanhamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Desligamentos_Funcionarios_FuncionarioId",
                table: "Desligamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_FitCulturals_Funcionarios_FuncionarioId",
                table: "FitCulturals");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cargos_CargoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MotivoDesligamentos_Funcionarios_FuncionarioId",
                table: "MotivoDesligamentos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "MotivoDesligamentos",
                newName: "Funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_MotivoDesligamentos_FuncionarioId",
                table: "MotivoDesligamentos",
                newName: "IX_MotivoDesligamentos_Funcionarioid");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "FitCulturals",
                newName: "Funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_FitCulturals_FuncionarioId",
                table: "FitCulturals",
                newName: "IX_FitCulturals_Funcionarioid");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Desligamentos",
                newName: "funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Desligamentos_FuncionarioId",
                table: "Desligamentos",
                newName: "IX_Desligamentos_funcionarioid");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Acompanhamentos",
                newName: "Funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Acompanhamentos_FuncionarioId",
                table: "Acompanhamentos",
                newName: "IX_Acompanhamentos_Funcionarioid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Funcionario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Funcionario",
                newName: "Cargo");

            migrationBuilder.AddColumn<Guid>(
                name: "Funcionarioid",
                table: "Desligamentos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Funcionarioid",
                table: "Funcionario",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Desligamentos_Funcionarioid",
                table: "Desligamentos",
                column: "Funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Funcionarioid",
                table: "Funcionario",
                column: "Funcionarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Acompanhamentos_Funcionario_Funcionarioid",
                table: "Acompanhamentos",
                column: "Funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Desligamentos_Funcionario_Funcionarioid",
                table: "Desligamentos",
                column: "Funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Desligamentos_Funcionario_funcionarioid",
                table: "Desligamentos",
                column: "funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitCulturals_Funcionario_Funcionarioid",
                table: "FitCulturals",
                column: "Funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Funcionario_Funcionarioid",
                table: "Funcionario",
                column: "Funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MotivoDesligamentos_Funcionario_Funcionarioid",
                table: "MotivoDesligamentos",
                column: "Funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
