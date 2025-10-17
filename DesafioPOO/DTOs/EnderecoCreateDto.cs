using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.DTOs;

public class EnderecoCreateDto
{
    [Required(ErrorMessage = "A rua é obrigatória")]
    public string Rua { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número é obrigatório")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "O bairro é obrigatório")]
    public string Bairro { get; set; } = string.Empty;

    [Required(ErrorMessage = "O complemento é obrigatório")]
    public string Complemento { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado é obrigatório")]
    public string Estado { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CEP é obrigatório")]
    public string Cep { get; set; } = string.Empty;
}
