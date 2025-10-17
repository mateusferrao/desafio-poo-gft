using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public abstract class Pessoa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    
    [Required]
    public string Nome { get; private set; } = string.Empty;
    
    [Required]
    public string Telefone { get; private set; } = string.Empty;

    [Required]
    public string Cpf { get; private set; } = string.Empty;
    
    protected Pessoa() { }

    protected Pessoa(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    public void SetNome(string nome) => Nome = nome;
    public void SetTelefone(string telefone) => Telefone = telefone;
    public void SetCpf(string cpf) => Cpf = cpf;

}