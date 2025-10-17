using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.Models;

public class Endereco
{
    public int Id { get; private set; }
    
    [Required]
    public string Rua { get; private set; }
    
    [Required]
    public int Numero { get; private set; }
    
    [Required]
    public string Bairro { get; private set; }
    
    public string Complemento { get; private set; }
    
    [Required]
    public string Cidade { get; private set; }
    
    [Required]
    public string Estado { get; private set; }
    
    [Required]
    public string Cep { get; private set; }

    // Construtor sem parâmetros (necessário para o EF)
    public Endereco() { }

    // Construtor com parâmetros (para uso no código)
    public Endereco(string rua, int numero, string bairro, string complemento, string cidade, string estado, string cep)
    {
        Rua = rua;
        Numero = numero;
        Bairro = bairro;
        Complemento = complemento;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public int GetId() => Id;
    public string GetRua() => Rua;
    public void SetRua(string rua) => Rua = rua;
    public int GetNumero() => Numero;
    public void SetNumero(int numero) => Numero = numero;
    public string GetBairro() => Bairro;
    public void SetBairro(string bairro) => Bairro = bairro;
    public string GetComplemento() => Complemento;
    public void SetComplemento(string complemento) => Complemento = complemento;
    public string GetCidade() => Cidade;
    public void SetCidade(string cidade) => Cidade = cidade;
    public string GetEstado() => Estado;
    public void SetEstado(string estado) => Estado = estado;
    public string GetCep() => Cep;
    public void SetCep(string cep) => Cep = cep;

}