namespace DesafioPOO.Models;

public class Casa : Imovel
{
    private static readonly decimal PORCENTAGEM_DE_ALUGUEL = 0.01m;
    
    public int NumeroQuartos { get; private set; }
    public int NumeroBanheiros { get; private set; }
    public bool TemGaragem { get; private set; }

    public Casa() { }

    public Casa(Endereco endereco, bool alugado, Proprietario proprietario, decimal valor, 
                int numeroQuartos, int numeroBanheiros, bool temGaragem) 
        : base(endereco, alugado, proprietario, valor)
    {
        NumeroQuartos = numeroQuartos;
        NumeroBanheiros = numeroBanheiros;
        TemGaragem = temGaragem;
    }

    public override string EstaAlugado()
    {
        return Alugado ? "A casa está alugada" : "A casa está disponível";
    }

    public override decimal CalcularAluguel(int prazoAnos)
    {
        return Valor * PORCENTAGEM_DE_ALUGUEL * (1 - CalcularDescontoAluguel(prazoAnos));
    }

    public override decimal CalcularDescontoAluguel(int prazoAnos)
    {
        decimal percentualDesconto = base.CalcularDescontoAluguel(prazoAnos);
        if (NumeroQuartos >= 5)
        {
            percentualDesconto += 0.03m;
        }
        return percentualDesconto;
    }

    public void SetNumeroQuartos(int numeroQuartos) => NumeroQuartos = numeroQuartos;
    public void SetNumeroBanheiros(int numeroBanheiros) => NumeroBanheiros = numeroBanheiros;
    public void SetTemGaragem(bool temGaragem) => TemGaragem = temGaragem;
}