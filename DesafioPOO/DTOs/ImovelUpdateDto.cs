namespace DesafioPOO.DTOs;

public class ImovelUpdateDto
{
    public int EnderecoId { get; set; }
    public bool Alugado { get; set; }
    public int ProprietarioId { get; set; }
    public double Tamanho { get; set; }
}
