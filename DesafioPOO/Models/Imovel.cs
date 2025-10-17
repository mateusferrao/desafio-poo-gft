using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public abstract class Imovel
{
    public int Id { get; private set; }
    
    [Required]
    public Endereco Endereco { get; private set; }
    
    [Required]
    public bool Alugado { get; private set; }
    
    [Required]
    public Proprietario Proprietario { get; private set; }
    
    [Required]
    public decimal Valor { get; private set; }

    protected Imovel() { }

    protected Imovel(Endereco endereco, bool alugado, Proprietario proprietario, decimal valor)
    {
        Endereco = endereco;
        Alugado = alugado;
        Proprietario = proprietario;
        Valor = valor;
    }

    public void SetAlugado(bool alugado)
    {
        if (alugado && Alugado)
        {
            throw new Exception("O imóvel já está alugado");
        }
        Alugado = alugado;
    }
    public void SetEndereco(Endereco endereco) => Endereco = endereco;
    public void SetProprietario(Proprietario proprietario) => Proprietario = proprietario;
    public void SetValor(decimal valor) => Valor = valor;
    public string ContatoProprietario()
    {
        return $"Nome: {Proprietario.Nome}, Telefone: {Proprietario.Telefone}, Cpf: {Proprietario.Cpf}";
    }

    public virtual string EstaAlugado()
    {
        return Alugado ? "O imóvel está alugado" : "O imóvel está disponível";
    }

    public abstract decimal CalcularAluguel(int prazoAnos);
    public virtual decimal CalcularDescontoAluguel(int prazoAnos)
    {
        if (prazoAnos >= 3)
        {
            return 0.05m;
        }
        return 0m;
    }
}