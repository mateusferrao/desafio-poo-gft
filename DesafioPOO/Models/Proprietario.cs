using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.Models;

public class Proprietario
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(20)]
    public string Telefone { get; set; } = string.Empty;

    public Proprietario() { }

    public Proprietario(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public string GetNome()
    {
        return Nome;
    }

    public string GetEmail()
    {
        return Email;
    }

    public string GetTelefone()
    {
        return Telefone;
    }
}