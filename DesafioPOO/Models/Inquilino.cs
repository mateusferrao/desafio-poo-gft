namespace DesafioPOO.Models;

public class Inquilino : Pessoa
{
    public Inquilino(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    public Inquilino(string nome, string telefone, string cpf, List<Imovel> imoveis)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        Imoveis = imoveis;
    }

}