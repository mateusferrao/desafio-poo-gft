using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public class Aluguel
{
    private int Id { get; set; }
    [Required]
    [ForeignKey("Imovel")]
    private Imovel Imovel { get; set; }
    [Required]
    [ForeignKey("Inquilino")]
    private Inquilino Inquilino { get; set; }
    [Required]
    private DateTime DataInicio { get; set; }
    [Required]
    private DateTime DataFim { get; set; }
    [Required]
    [MinLength(0)]
    private decimal Valor { get; set; }

    public Aluguel(Imovel imovel, Inquilino inquilino, DateTime dataInicio, DateTime dataFim, decimal valor)
    {
        Imovel = imovel;
        Inquilino = inquilino;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Valor = valor;
        Imovel.SetAlugado(true);
    }

    public int GetId() => Id;
    public Imovel GetImovel() => Imovel;
    public void SetImovel(Imovel imovel) => Imovel = imovel;
    public Inquilino GetInquilino() => Inquilino;
    public void SetInquilino(Inquilino inquilino) => Inquilino = inquilino;
    public DateTime GetDataInicio() => DataInicio;
    public void SetDataInicio(DateTime dataInicio) => DataInicio = dataInicio;
    public DateTime GetDataFim() => DataFim;
    public void SetDataFim(DateTime dataFim) => DataFim = dataFim;
    public decimal GetValor() => Valor;
    public void SetValor(decimal valor) => Valor = valor;
}