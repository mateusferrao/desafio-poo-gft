namespace DesafioPOO.Models;

public class Inquilino : Pessoa
{
    public Inquilino() { }

    public Inquilino(string nome, string telefone, string cpf) 
        : base(nome, telefone, cpf)
    {
    }
}