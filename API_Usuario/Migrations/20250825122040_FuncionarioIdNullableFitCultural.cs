using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioIdNullableFitCultural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "fitculturals",
                nullable: true,
                type: "char(36)",
                collation: "ascii_general_ci"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "fitculturals",
                nullable: false,
                type: "char(36)",
                collation: "ascii_general_ci"
            );
        }
    }
}
