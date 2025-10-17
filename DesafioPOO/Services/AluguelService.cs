using DesafioPOO.Models;
using DesafioPOO.Repositories;

namespace DesafioPOO.Services;

public class AluguelService
{
    private readonly AluguelRepository _aluguelRepository;

    public AluguelService(AluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }

    public async Task<List<Aluguel>> BuscarTodosAlugueisAsync()
    {
        return await _aluguelRepository.GetAllAsync();
    }

    public async Task<Aluguel?> BuscarAluguelPorIdAsync(int id)
    {
        return await _aluguelRepository.GetByIdAsync(id);
    }

    public async Task<List<Aluguel>> BuscarAlugueisPorInquilinoAsync(int inquilinoId)
    {
        return await _aluguelRepository.GetByInquilinoIdAsync(inquilinoId);
    }

    public async Task<List<Aluguel>> BuscarAlugueisPorImovelAsync(int imovelId)
    {
        return await _aluguelRepository.GetByImovelIdAsync(imovelId);
    }

    public async Task<Aluguel> AdicionarAluguelAsync(Aluguel aluguel)
    {
        return await _aluguelRepository.AddAsync(aluguel);
    }

    public async Task<Aluguel> AtualizarAluguelAsync(Aluguel aluguel)
    {
        return await _aluguelRepository.UpdateAsync(aluguel);
    }

    public async Task<Aluguel> DeletarAluguelAsync(int id)
    {
        var aluguel = await _aluguelRepository.GetByIdAsync(id);
        if (aluguel == null)
        {
            throw new ArgumentException($"Aluguel com ID {id} não encontrado.");
        }
        return await _aluguelRepository.DeleteAsync(aluguel);
    }
}
