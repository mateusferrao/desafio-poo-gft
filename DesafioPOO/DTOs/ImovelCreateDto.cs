using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.DTOs;

public class ImovelCreateDto
{
    [Required(ErrorMessage = "O ID do endereço é obrigatório")]
    public int EnderecoId { get; set; }

    [Required(ErrorMessage = "O status de alugado é obrigatório")]
    public bool Alugado { get; set; }

    [Required(ErrorMessage = "O ID do proprietário é obrigatório")]
    public int ProprietarioId { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.1, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Valor { get; set; }
}
