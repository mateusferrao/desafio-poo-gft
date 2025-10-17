namespace DesafioPOO.Models;

public class Casa(Endereco endereco, bool alugado, Proprietario proprietario, double tamanho) : Imovel(endereco, alugado, proprietario, tamanho)
{
    private static readonly double PORCENTAGEM_DE_ALUGUEL = 0.01;
    public override string EstaAlugado()
    {
        return Alugado ? "A casa está alugada" : "A casa está disponível";
    }

    public override double CalcularAluguel()
    {
        return Tamanho * PORCENTAGEM_DE_ALUGUEL;
    }
}