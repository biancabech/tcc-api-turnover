using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class AddChaveUnicaCpfFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(name: "cpf", table: "funcionarios", type: "char(11)", nullable: false);
            migrationBuilder.AddUniqueConstraint(name: "uniq_funcionario_cpf", table: "funcionarios", columns: ["cpf"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint("uniq_funcionario_cpf", "funcionarios");
            migrationBuilder.AlterColumn<string>(name: "cpf", table: "funcionarios", type: "longtext", nullable: false);
        }
    }
}
