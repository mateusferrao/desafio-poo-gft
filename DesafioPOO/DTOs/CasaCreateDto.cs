using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.DTOs;

public class CasaCreateDto
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

    [Required(ErrorMessage = "O número de quartos é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O número de quartos deve ser maior que zero")]
    public int NumeroQuartos { get; set; }

    [Required(ErrorMessage = "O número de banheiros é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O número de banheiros deve ser maior que zero")]
    public int NumeroBanheiros { get; set; }

    [Required(ErrorMessage = "A informação sobre garagem é obrigatória")]
    public bool TemGaragem { get; set; }
}
