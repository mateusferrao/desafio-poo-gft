namespace DesafioPOO.Models;

public abstract class Pessoa
{
    protected string Nome { get; set; }
    protected string Telefone { get; set; }
    protected string Cpf { get ; set; }
    protected List<Imovel> Imoveis { get; set; }


    public string GetNome() => Nome;
    public void SetNome(string nome) => Nome = nome;
    public string GetTelefone() => Telefone;
    public void SetTelefone(string telefone) => Telefone = telefone;
    public string GetCpf() => Cpf;
    public void SetCpf(string cpf) => Cpf = cpf;
    public List<Imovel> GetImoveis() => Imoveis;
    public void SetImoveis(List<Imovel> imoveis) => Imoveis = imoveis;
}