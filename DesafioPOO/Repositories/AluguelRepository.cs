using DesafioPOO.Data;
using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Repositories;

public class AluguelRepository
{
    private readonly CorretoraContext _context;

    public AluguelRepository(CorretoraContext context)
    {
        _context = context;
    }

    public async Task<List<Aluguel>> GetAllAsync()
    {
        return await _context.Alugueis
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Endereco)
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Proprietario)
            .Include(a => a.Inquilino)
            .ToListAsync();
    }

    public async Task<Aluguel?> GetByIdAsync(int id)
    {
        return await _context.Alugueis
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Endereco)
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Proprietario)
            .Include(a => a.Inquilino)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Aluguel>> GetByInquilinoIdAsync(int inquilinoId)
    {
        return await _context.Alugueis
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Endereco)
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Proprietario)
            .Include(a => a.Inquilino)
            .Where(a => a.Inquilino.Id == inquilinoId)
            .ToListAsync();
    }

    public async Task<List<Aluguel>> GetByImovelIdAsync(int imovelId)
    {
        return await _context.Alugueis
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Endereco)
            .Include(a => a.Imovel)
                .ThenInclude(i => i.Proprietario)
            .Include(a => a.Inquilino)
            .Where(a => a.Imovel.Id == imovelId)
            .ToListAsync();
    }

    public async Task<Aluguel> AddAsync(Aluguel aluguel)
    {
        _context.Alugueis.Add(aluguel);
        await _context.SaveChangesAsync();
        return aluguel;
    }

    public async Task<Aluguel> UpdateAsync(Aluguel aluguel)
    {
        _context.Alugueis.Update(aluguel);
        await _context.SaveChangesAsync();
        return aluguel;
    }

    public async Task<Aluguel> DeleteAsync(Aluguel aluguel)
    {
        _context.Alugueis.Remove(aluguel);
        await _context.SaveChangesAsync();
        return aluguel;
    }
}
