using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.DTOs;

public class AluguelCreateDto
{
    [Required(ErrorMessage = "O ID do imóvel é obrigatório")]
    public int ImovelId { get; set; }

    [Required(ErrorMessage = "O ID do inquilino é obrigatório")]
    public int InquilinoId { get; set; }

    [Required(ErrorMessage = "A data de início é obrigatória")]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "A data de fim é obrigatória")]
    public DateTime DataFim { get; set; }
}
