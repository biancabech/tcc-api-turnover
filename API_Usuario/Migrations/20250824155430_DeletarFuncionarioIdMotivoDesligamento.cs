using API_Usuario.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class DeletarFuncionarioIdMotivoDesligamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_MotivoDesligamentos_Funcionarios_FuncionarioId", "motivodesligamentos");
            migrationBuilder.DropForeignKey("FK_MotivoDesligamentos_Desligamentos_DesligamentoId", "motivodesligamentos");

            migrationBuilder.DropColumn("FuncionarioId", "motivodesligamentos");
            migrationBuilder.DropColumn("DesligamentoId", "motivodesligamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new Exception("Essa migration é irreversível");
        }
    }
}
