using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.Models;

public class Endereco(string rua, int numero, string bairro, string complemento, string cidade, string estado, string cep)
{
    private int Id { get; set; }
    private string Rua { get; set; } = rua;
    private int Numero { get; set; } = numero;
    private string Bairro { get; set; } = bairro;
    private string Complemento { get; set; } = complemento;
    private string Cidade { get; set; } = cidade;
    private string Estado { get; set; } = estado;
    [Required]
    private string Cep { get; set; } = cep;

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