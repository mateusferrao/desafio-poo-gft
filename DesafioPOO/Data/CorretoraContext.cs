using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Data
{
    public class CorretoraContext(DbContextOptions<CorretoraContext> options) : DbContext(options)
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
    }
}