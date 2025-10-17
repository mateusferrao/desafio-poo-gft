using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioPOO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false),
                    Alugado = table.Column<bool>(type: "boolean", nullable: false),
                    ProprietarioId = table.Column<string>(type: "text", nullable: true),
                    Tamanho = table.Column<double>(type: "double precision", nullable: false),
                    InquilinoCpf = table.Column<string>(type: "text", nullable: true),
                    ProprietarioCpf = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Andar = table.Column<int>(type: "integer", nullable: true),
                    NumeroApartamento = table.Column<string>(type: "text", nullable: true),
                    NumeroQuartos = table.Column<int>(type: "integer", nullable: true),
                    NumeroBanheiros = table.Column<int>(type: "integer", nullable: true),
                    TemGaragem = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imoveis_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imoveis_Pessoas_InquilinoCpf",
                        column: x => x.InquilinoCpf,
                        principalTable: "Pessoas",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_Imoveis_Pessoas_ProprietarioCpf",
                        column: x => x.ProprietarioCpf,
                        principalTable: "Pessoas",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_Imoveis_Pessoas_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Pessoas",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImovelId = table.Column<int>(type: "integer", nullable: false),
                    InquilinoId = table.Column<string>(type: "text", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alugueis_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alugueis_Pessoas_InquilinoId",
                        column: x => x.InquilinoId,
                        principalTable: "Pessoas",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_ImovelId",
                table: "Alugueis",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_InquilinoId",
                table: "Alugueis",
                column: "InquilinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_EnderecoId",
                table: "Imoveis",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_InquilinoCpf",
                table: "Imoveis",
                column: "InquilinoCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ProprietarioCpf",
                table: "Imoveis",
                column: "ProprietarioCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ProprietarioId",
                table: "Imoveis",
                column: "ProprietarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
