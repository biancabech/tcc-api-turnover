using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Usuario.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PontosBaixos",
                table: "Acompanhamentos",
                newName: "Treinamento");

            migrationBuilder.RenameColumn(
                name: "PontosAltos",
                table: "Acompanhamentos",
                newName: "Qualidade");

            migrationBuilder.RenameColumn(
                name: "FeedFuncion",
                table: "Acompanhamentos",
                newName: "Produtividade");

            migrationBuilder.RenameColumn(
                name: "FeedEmpresa",
                table: "Acompanhamentos",
                newName: "Prazos");

            migrationBuilder.RenameColumn(
                name: "DataFeedBack",
                table: "Acompanhamentos",
                newName: "Plano");

            migrationBuilder.AddColumn<bool>(
                name: "Adaptabilidade",
                table: "Acompanhamentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Avaliador",
                table: "Acompanhamentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Comunicacao",
                table: "Acompanhamentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Confirmacao",
                table: "Acompanhamentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Acompanhamentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Proatividade",
                table: "Acompanhamentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TrabalhoEquipe",
                table: "Acompanhamentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adaptabilidade",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "Avaliador",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "Comunicacao",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "Confirmacao",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "Proatividade",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "TrabalhoEquipe",
                table: "Acompanhamentos");

            migrationBuilder.RenameColumn(
                name: "Treinamento",
                table: "Acompanhamentos",
                newName: "PontosBaixos");

            migrationBuilder.RenameColumn(
                name: "Qualidade",
                table: "Acompanhamentos",
                newName: "PontosAltos");

            migrationBuilder.RenameColumn(
                name: "Produtividade",
                table: "Acompanhamentos",
                newName: "FeedFuncion");

            migrationBuilder.RenameColumn(
                name: "Prazos",
                table: "Acompanhamentos",
                newName: "FeedEmpresa");

            migrationBuilder.RenameColumn(
                name: "Plano",
                table: "Acompanhamentos",
                newName: "DataFeedBack");
        }
    }
}
