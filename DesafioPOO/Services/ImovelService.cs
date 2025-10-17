using DesafioPOO.Models;
using DesafioPOO.Repositories;

namespace DesafioPOO.Services;

public class ImovelService
{
    private readonly ImovelRepository _imovelRepository;

    public ImovelService(ImovelRepository imovelRepository)
    {
        _imovelRepository = imovelRepository;
    }

    public async Task<List<Imovel>> BuscarTodosImoveisAsync()
    {
        return await _imovelRepository.GetAllAsync();
    }

    public async Task<List<Casa>> BuscarTodasCasasAsync()
    {
        return await _imovelRepository.GetAllCasasAsync();
    }

    public async Task<List<Apartamento>> BuscarTodosApartamentosAsync()
    {
        return await _imovelRepository.GetAllApartamentosAsync();
    }

    public async Task<Imovel?> BuscarImovelPorIdAsync(int id)
    {
        return await _imovelRepository.GetByIdAsync(id);
    }

    public async Task<Imovel> AdicionarImovelAsync(Imovel imovel)
    {
        return await _imovelRepository.AddAsync(imovel);
    }

    public async Task<Imovel> AtualizarImovelAsync(Imovel imovel)
    {
        return await _imovelRepository.UpdateAsync(imovel);
    }

    public async Task<Imovel> DeletarImovelAsync(int id)
    {
        var imovel = await _imovelRepository.GetByIdAsync(id);
        if (imovel == null)
        {
            throw new ArgumentException($"Imóvel com ID {id} não encontrado.");
        }
        return await _imovelRepository.DeleteAsync(imovel);
    }
}
