namespace DesafioPOO.Models;

public class Proprietario : Pessoa
{
    // Construtor sem parâmetros (necessário para o EF)
    public Proprietario() { }

    // Construtor com parâmetros (para uso no código)
    public Proprietario(string nome, string telefone, string cpf) 
        : base(nome, telefone, cpf)
    {
    }

    // Construtor com parâmetros incluindo imóveis
    public Proprietario(string nome, string telefone, string cpf, List<Imovel> imoveis) 
        : base(nome, telefone, cpf, imoveis)
    {
    }
}