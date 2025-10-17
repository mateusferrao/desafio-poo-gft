namespace DesafioPOO.DTOs;

public class AluguelUpdateDto
{
    public int ImovelId { get; set; }
    public int InquilinoId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }
}
