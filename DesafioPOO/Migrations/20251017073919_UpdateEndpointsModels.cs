using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPOO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEndpointsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Imoveis");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Imoveis",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Imoveis");

            migrationBuilder.AddColumn<double>(
                name: "Tamanho",
                table: "Imoveis",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
