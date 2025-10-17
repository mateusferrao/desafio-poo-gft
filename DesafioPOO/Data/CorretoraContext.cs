using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Data
{
    public class CorretoraContext(DbContextOptions<CorretoraContext> options) : DbContext(options)
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Casa> Casas { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Proprietario>("Proprietario")
                .HasValue<Inquilino>("Inquilino");

            modelBuilder.Entity<Imovel>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<Casa>("Casa")
                .HasValue<Apartamento>("Apartamento");

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Imovel)
                .WithMany()
                .HasForeignKey("ImovelId");

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Inquilino)
                .WithMany()
                .HasForeignKey("InquilinoId");

            modelBuilder.Entity<Imovel>()
                .HasOne(i => i.Endereco)
                .WithMany()
                .HasForeignKey("EnderecoId");

            modelBuilder.Entity<Imovel>()
                .HasOne(i => i.Proprietario)
                .WithMany()
                .HasForeignKey("ProprietarioId");

            base.OnModelCreating(modelBuilder);
        }
    }
}