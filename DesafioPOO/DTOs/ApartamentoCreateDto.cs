using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.DTOs;

public class ApartamentoCreateDto
{
    [Required(ErrorMessage = "O ID do endereço é obrigatório")]
    public int EnderecoId { get; set; }

    [Required(ErrorMessage = "O status de alugado é obrigatório")]
    public bool Alugado { get; set; }

    [Required(ErrorMessage = "O ID do proprietário é obrigatório")]
    public int ProprietarioId { get; set; }

    [Required(ErrorMessage = "O tamanho é obrigatório")]
    [Range(0.1, double.MaxValue, ErrorMessage = "O tamanho deve ser maior que zero")]
    public double Tamanho { get; set; }

    [Required(ErrorMessage = "O andar é obrigatório")]
    [Range(0, int.MaxValue, ErrorMessage = "O andar deve ser maior ou igual a zero")]
    public int Andar { get; set; }

    [Required(ErrorMessage = "O número do apartamento é obrigatório")]
    public string NumeroApartamento { get; set; } = string.Empty;
}
