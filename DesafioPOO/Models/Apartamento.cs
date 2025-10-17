namespace DesafioPOO.Models;

public class Apartamento : Imovel
{
    public Apartamento(Endereco endereco, bool alugado, Proprietario proprietario)
    {
        Endereco = endereco;
        Alugado = alugado;
        Proprietario = proprietario;
    }

    public Apartamento(Endereco endereco, bool alugado, Proprietario proprietario, Inquilino inquilino)
    {
        Endereco = endereco;
        Alugado = alugado;
        Proprietario = proprietario;
        Inquilino = inquilino;
    }

    public override string EstaAlugado()
    {
        return Alugado ? "O apartamento está alugado" : "O apartamento está disponível";
    }
}