using DesafioPOO.Data;
using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Repositories;

public class ImovelRepository
{
    private readonly CorretoraContext _context;

    public ImovelRepository(CorretoraContext context)
    {
        _context = context;
    }

    public async Task<List<Imovel>> GetAllAsync()
    {
        return await _context.Imoveis
            .Include(i => i.Endereco)
            .Include(i => i.Proprietario)
            .ToListAsync();
    }

    public async Task<List<Casa>> GetAllCasasAsync()
    {
        return await _context.Imoveis.OfType<Casa>()
            .Include(i => i.Endereco)
            .Include(i => i.Proprietario)
            .ToListAsync();
    }

    public async Task<List<Apartamento>> GetAllApartamentosAsync()
    {
        return await _context.Imoveis.OfType<Apartamento>()
            .Include(i => i.Endereco)
            .Include(i => i.Proprietario)
            .ToListAsync();
    }

    public async Task<List<Imovel>> GetImoveisAlugadosAsync()
    {
        return await _context.Imoveis
            .Include(i => i.Endereco)
            .Include(i => i.Proprietario)
            .Where(i => i.Alugado == true)
            .ToListAsync();
    }

    public async Task<Imovel?> GetByIdAsync(int id)
    {
        return await _context.Imoveis
            .Include(i => i.Endereco)
            .Include(i => i.Proprietario)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Imovel> AddAsync(Imovel imovel)
    {
        _context.Imoveis.Add(imovel);
        await _context.SaveChangesAsync();
        return imovel;
    }

    public async Task<Imovel> UpdateAsync(Imovel imovel)
    {
        _context.Imoveis.Update(imovel);
        await _context.SaveChangesAsync();
        return imovel;
    }

    public async Task<Imovel> DeleteAsync(Imovel imovel)
    {
        _context.Imoveis.Remove(imovel);
        await _context.SaveChangesAsync();
        return imovel;
    }
}
