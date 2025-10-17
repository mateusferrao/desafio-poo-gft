namespace DesafioPOO.Models;

public abstract class Imovel
{
    protected Endereco Endereco { get; set; }
    protected bool Alugado { get; set; }
    protected Proprietario Proprietario { get; set; }

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

    public string ContatoProprietario()
    {
        return $"Nome: {Proprietario.GetNome()}, Telefone: {Proprietario.GetTelefone()}, Cpf: {Proprietario.GetCpf()}";
    }

    public virtual string EstaAlugado()
    {
        return Alugado ? "O imóvel está alugado" : "O imóvel está disponível";
    }

    // public abstract int CalcularAluguel();

}