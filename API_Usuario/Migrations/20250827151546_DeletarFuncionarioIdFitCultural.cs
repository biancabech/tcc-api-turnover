using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class DeletarFuncionarioIdFitCultural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_FitCulturals_Funcionarios_FuncionarioId", "fitculturals");
            migrationBuilder.DropColumn("FuncionarioId", "fitculturals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new Exception("Essa migration é irreversível");
        }
    }

}
