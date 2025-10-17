namespace DesafioPOO.Models;

public class Inquilino : Pessoa
{
    // Construtor sem parâmetros (necessário para o EF)
    public Inquilino() { }

    // Construtor com parâmetros (para uso no código)
    public Inquilino(string nome, string telefone, string cpf) 
        : base(nome, telefone, cpf)
    {
    }

    // Construtor com parâmetros incluindo imóveis
    public Inquilino(string nome, string telefone, string cpf, List<Imovel> imoveis) 
        : base(nome, telefone, cpf, imoveis)
    {
    }
}