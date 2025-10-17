namespace DesafioPOO.Models;

public class Apartamento(Endereco endereco, bool alugado, Proprietario proprietario, double tamanho) : Imovel(endereco, alugado, proprietario, tamanho)
{
    private static readonly double PORCENTAGEM_DE_ALUGUEL = 0.007;
    public override string EstaAlugado()
    {
        return Alugado ? "O apartamento está alugado" : "O apartamento está disponível";
    }

    public override double CalcularAluguel()
    {
        return Tamanho * PORCENTAGEM_DE_ALUGUEL;
    }
}