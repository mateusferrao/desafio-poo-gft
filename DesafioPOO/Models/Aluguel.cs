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

    // Construtor sem parâmetros (necessário para o EF)
    public Aluguel() { }

    // Construtor com parâmetros (para uso no código)
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