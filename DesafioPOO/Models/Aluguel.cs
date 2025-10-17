namespace DesafioPOO.Models;

public class Aluguel()
{
    public Imovel Imovel { get; set; }
    public Inquilino Inquilino { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }

    public Aluguel(Imovel imovel, Inquilino inquilino, DateTime dataInicio, DateTime dataFim, decimal valor) : this()
    {
        Imovel = imovel;
        Inquilino = inquilino;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Valor = valor;
        Imovel.SetAlugado(true);
    }
}