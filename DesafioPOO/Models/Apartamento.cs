namespace DesafioPOO.Models;

public class Apartamento : Imovel
{
    private static readonly decimal PORCENTAGEM_DE_ALUGUEL = 0.007m;
    
    public int Andar { get; private set; }
    public string NumeroApartamento { get; private set; }

    public Apartamento() { }

    public Apartamento(Endereco endereco, bool alugado, Proprietario proprietario, decimal valor, 
                       int andar, string numeroApartamento) 
        : base(endereco, alugado, proprietario, valor)
    {
        Andar = andar;
        NumeroApartamento = numeroApartamento;
    }

    public override string EstaAlugado()
    {
        return Alugado ? "O apartamento está alugado" : "O apartamento está disponível";
    }

    public override decimal CalcularAluguel(int prazoAnos)
    {
        return Valor * PORCENTAGEM_DE_ALUGUEL * (1 - CalcularDescontoAluguel(prazoAnos));
    }

    public override decimal CalcularDescontoAluguel(int prazoAnos)
    {
        decimal percentualDesconto = base.CalcularDescontoAluguel(prazoAnos);
        
        if (Andar <= 2)
        {
            percentualDesconto += 0.02m;
        }
        return percentualDesconto;
    }

    public void SetAndar(int andar) => Andar = andar;
    public void SetNumeroApartamento(string numeroApartamento) => NumeroApartamento = numeroApartamento;
}