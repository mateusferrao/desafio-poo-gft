namespace DesafioPOO.Models;

public class Proprietario : Pessoa
{
    public Proprietario() { }

    public Proprietario(string nome, string telefone, string cpf) 
        : base(nome, telefone, cpf)
    {
    }
}