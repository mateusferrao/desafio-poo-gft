using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.Models;

public abstract class Imovel
{
    public int Id { get; set; }
    
    [Required]
    public int Numero { get; set; }
    
    [Required]
    public bool Alugado { get; set; }
    
    [Required]
    public int ProprietarioId { get; set; }
    public Proprietario Proprietario { get; set; } = null!;
    
    [Required]
    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; } = null!;

    public virtual bool EstaAlugado()
    {
        return Alugado;
    }

    public string ContatoProprietario()
    {
        return $"Nome: {Proprietario.GetNome()}, Email: {Proprietario.GetEmail()}, Telefone: {Proprietario.GetTelefone()}";
    }
}

public class Casa : Imovel
{
    public int NumeroQuartos { get; set; }
    public int NumeroBanheiros { get; set; }
    public bool TemGaragem { get; set; }
    public double AreaTerreno { get; set; }
}

public class Apartamento : Imovel
{
    public int NumeroQuartos { get; set; }
    public int NumeroBanheiros { get; set; }
    public int NumeroVagasGaragem { get; set; }
    public int Andar { get; set; }
    public double AreaUtil { get; set; }
}