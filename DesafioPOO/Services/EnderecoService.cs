using DesafioPOO.Models;
using DesafioPOO.Repositories;

namespace DesafioPOO.Services;

public class EnderecoService
{
    private readonly EnderecoRepository _enderecoRepository;

    public EnderecoService(EnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public async Task<List<Endereco>> BuscarTodosEnderecosAsync()
    {
        return await _enderecoRepository.GetAllAsync();
    }

    public async Task<Endereco?> BuscarEnderecoPorIdAsync(int id)
    {
        return await _enderecoRepository.GetByIdAsync(id);
    }

    public async Task<Endereco> AdicionarEnderecoAsync(Endereco endereco)
    {
        return await _enderecoRepository.AddAsync(endereco);
    }

    public async Task<Endereco> AtualizarEnderecoAsync(Endereco endereco)
    {
        return await _enderecoRepository.UpdateAsync(endereco);
    }

    public async Task<Endereco> DeletarEnderecoAsync(int id)
    {
        var endereco = await _enderecoRepository.GetByIdAsync(id);
        if (endereco == null)
        {
            throw new ArgumentException($"Endereço com ID {id} não encontrado.");
        }
        return await _enderecoRepository.DeleteAsync(endereco);
    }
}
