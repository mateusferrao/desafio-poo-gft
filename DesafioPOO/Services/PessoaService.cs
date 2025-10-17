using DesafioPOO.Models;
using DesafioPOO.Repositories;

namespace DesafioPOO.Services;

public class PessoaService(PessoaRepository pessoaRepository)
{
    private readonly PessoaRepository _pessoaRepository = pessoaRepository;

    public async Task<List<Pessoa>> BuscarTodasPessoasAsync()
    {
        return await _pessoaRepository.GetAllAsync();
    }

    public async Task<List<Inquilino>> BuscarTodosInquilinosAsync()
    {
        return await _pessoaRepository.GetAllInquilinosAsync();
    }

    public async Task<List<Proprietario>> BuscarTodosProprietariosAsync()
    {
        return await _pessoaRepository.GetAllProprietariosAsync();
    }

    public async Task<Pessoa?> BuscarPessoaPorIdAsync(int id)
    {
        return await _pessoaRepository.GetByIdAsync(id);
    }

    public async Task<Pessoa> AdicionarPessoaAsync(Pessoa pessoa)
    {
        return await _pessoaRepository.AddAsync(pessoa);
    }

    public async Task<Pessoa> AtualizarPessoaAsync(Pessoa pessoa)
    {
        return await _pessoaRepository.UpdateAsync(pessoa);
    }

    public async Task<Pessoa> DeletarPessoaAsync(int id)
    {
        return await _pessoaRepository.DeleteAsync(id);
    }
}