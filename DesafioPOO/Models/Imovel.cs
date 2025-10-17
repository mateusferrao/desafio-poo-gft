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
    public Double Tamanho { get; private set; }

    protected Imovel() { }

    protected Imovel(Endereco endereco, bool alugado, Proprietario proprietario, double tamanho)
    {
        Endereco = endereco;
        Alugado = alugado;
        Proprietario = proprietario;
        Tamanho = tamanho;
    }

    public int GetId() => Id;
    public bool GetAlugado() => Alugado;
    public void SetAlugado(bool alugado)
    {
        if (alugado && Alugado)
        {
            throw new Exception("O imóvel já está alugado");
        }
        Alugado = alugado;
    }
    public Endereco GetEndereco() => Endereco;
    public void SetEndereco(Endereco endereco) => Endereco = endereco;
    public Proprietario GetProprietario() => Proprietario;
    public void SetProprietario(Proprietario proprietario) => Proprietario = proprietario;
    public Double GetTamanho() => Tamanho;
    public void SetTamanho(Double tamanho) => Tamanho = tamanho;
    public string ContatoProprietario()
    {
        return $"Nome: {Proprietario.GetNome()}, Telefone: {Proprietario.GetTelefone()}, Cpf: {Proprietario.GetCpf()}";
    }

    public virtual string EstaAlugado()
    {
        return Alugado ? "O imóvel está alugado" : "O imóvel está disponível";
    }

    public abstract Double CalcularAluguel();

}