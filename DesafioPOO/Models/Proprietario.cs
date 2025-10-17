namespace DesafioPOO.Models;

public class Proprietario : Pessoa
{
    public Proprietario(string nome, string telefone, string cpf, List<Imovel> imoveis)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        Imoveis = imoveis;
    }

}