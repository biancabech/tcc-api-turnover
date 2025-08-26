using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class AddMotivoDsligamentoIdDesligamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MotivoDesligamentoId", 
                table: "desligamentos", 
                type: "char(36)", 
                nullable: false, 
                collation: "ascii_general_ci"
            );
            migrationBuilder.AddForeignKey(
                name: "FK_Desligamentos_MotivoDesligamentoId", 
                table: "desligamentos",
                column: "MotivoDesligamentoId", 
                principalTable: "motivodesligamentos",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Desligamentos_MotivoDesligamentoId", "desligamentos");
            migrationBuilder.DropColumn("MotivoDesligamentoId", "desligamentos");
        }
    }
}
