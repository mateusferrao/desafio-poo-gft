using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public abstract class Pessoa
{
    public int Id { get; private set; }
    
    [Required]
    public string Nome { get; private set; } = string.Empty;
    
    [Required]
    public string Telefone { get; private set; } = string.Empty;

    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Cpf { get; private set; } = string.Empty;
    
    public List<Imovel> Imoveis { get; private set; } = [];

    // Construtor sem parâmetros (necessário para o EF)
    protected Pessoa() { }

    // Construtor com parâmetros (para uso no código)
    protected Pessoa(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    // Construtor com parâmetros incluindo imóveis
    protected Pessoa(string nome, string telefone, string cpf, List<Imovel> imoveis)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        Imoveis = imoveis;
    }

    public string GetNome() => Nome;
    public void SetNome(string nome) => Nome = nome;
    public string GetTelefone() => Telefone;
    public void SetTelefone(string telefone) => Telefone = telefone;
    public string GetCpf() => Cpf;
    public void SetCpf(string cpf) => Cpf = cpf;
    public List<Imovel> GetImoveis() => Imoveis;
    public void SetImoveis(List<Imovel> imoveis) => Imoveis = imoveis;
}