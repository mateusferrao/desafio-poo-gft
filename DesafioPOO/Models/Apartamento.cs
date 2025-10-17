namespace DesafioPOO.Models;

public class Apartamento : Imovel
{
    private static readonly double PORCENTAGEM_DE_ALUGUEL = 0.007;
    
    public int Andar { get; private set; }
    public string NumeroApartamento { get; private set; }

    // Construtor sem parâmetros (necessário para o EF)
    public Apartamento() { }

    // Construtor com parâmetros (para uso no código)
    public Apartamento(Endereco endereco, bool alugado, Proprietario proprietario, double tamanho, 
                       int andar, string numeroApartamento) 
        : base(endereco, alugado, proprietario, tamanho)
    {
        Andar = andar;
        NumeroApartamento = numeroApartamento;
    }

    public override string EstaAlugado()
    {
        return Alugado ? "O apartamento está alugado" : "O apartamento está disponível";
    }

    public override double CalcularAluguel()
    {
        return Tamanho * PORCENTAGEM_DE_ALUGUEL;
    }
}