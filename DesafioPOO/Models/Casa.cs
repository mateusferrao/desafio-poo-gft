namespace DesafioPOO.Models;

public class Casa : Imovel
{
    public Casa(Endereco endereco, bool alugado, Proprietario proprietario)
    {
        Endereco = endereco;
        Alugado = alugado;
        Proprietario = proprietario;
    }

    public Casa(Endereco endereco, bool alugado, Proprietario proprietario, Inquilino inquilino)
    {
        Endereco = endereco;
        Alugado = alugado;
        Proprietario = proprietario;
        Inquilino = inquilino;
    }

    public override string EstaAlugado()
    {
        return Alugado ? "A casa está alugada" : "A casa está disponível";
    }
}