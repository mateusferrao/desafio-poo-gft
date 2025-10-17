namespace DesafioPOO.Models;

public class Casa : Imovel
{
    private static readonly double PORCENTAGEM_DE_ALUGUEL = 0.01;
    
    public int NumeroQuartos { get; private set; }
    public int NumeroBanheiros { get; private set; }
    public bool TemGaragem { get; private set; }

    public Casa() { }

    public Casa(Endereco endereco, bool alugado, Proprietario proprietario, double tamanho, 
                int numeroQuartos, int numeroBanheiros, bool temGaragem) 
        : base(endereco, alugado, proprietario, tamanho)
    {
        NumeroQuartos = numeroQuartos;
        NumeroBanheiros = numeroBanheiros;
        TemGaragem = temGaragem;
    }

    public override string EstaAlugado()
    {
        return Alugado ? "A casa está alugada" : "A casa está disponível";
    }

    public override double CalcularAluguel()
    {
        return Tamanho * PORCENTAGEM_DE_ALUGUEL;
    }
}