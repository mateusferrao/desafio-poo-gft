using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public class Aluguel
{
    public int Id { get; private set; }
    
    [Required]
    public Imovel Imovel { get; private set; }
    
    [Required]
    public Inquilino Inquilino { get; private set; }
    
    [Required]
    public DateTime DataInicio { get; private set; }
    
    [Required]
    public DateTime DataFim { get; private set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Valor { get; private set; }

    public Aluguel() { }

    public Aluguel(Imovel imovel, Inquilino inquilino, DateTime dataInicio, DateTime dataFim)
    {
        Imovel = imovel;
        Inquilino = inquilino;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Valor = Imovel.CalcularAluguel((int)(dataFim - dataInicio).TotalDays / 365);
        Imovel.SetAlugado(true);
    }
    public void SetImovel(Imovel imovel) => Imovel = imovel;
    public void SetInquilino(Inquilino inquilino) => Inquilino = inquilino;
    public void SetDataInicio(DateTime dataInicio) => DataInicio = dataInicio;
    public void SetDataFim(DateTime dataFim) => DataFim = dataFim;
    public void SetValor(decimal valor) => Valor = valor;
}