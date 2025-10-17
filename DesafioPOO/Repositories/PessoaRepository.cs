using DesafioPOO.Data;
using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Repositories;

public class PessoaRepository(CorretoraContext context)
{
    private readonly CorretoraContext _context = context;

    public async Task<List<Pessoa>> GetAllAsync()
    {
        return await _context.Pessoas.ToListAsync();
    }
    public async Task<List<Inquilino>> GetAllInquilinosAsync()
    {
        return await _context.Pessoas.OfType<Inquilino>().ToListAsync();
    }

    public async Task<List<Proprietario>> GetAllProprietariosAsync()
    {
        return await _context.Pessoas.OfType<Proprietario>().ToListAsync();
    }

    public async Task<Pessoa?> GetByIdAsync(int id)
    {
        return await _context.Pessoas.FindAsync(id);
    }

    public async Task<Pessoa> AddAsync(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return pessoa;
    }

    public async Task<Pessoa> UpdateAsync(Pessoa pessoa)
    {
        _context.Pessoas.Update(pessoa);
        await _context.SaveChangesAsync();
        return pessoa;
    }

    public async Task<Pessoa> DeleteAsync(int id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id) ?? throw new Exception("Pessoa não encontrada");
        _context.Pessoas.Remove(pessoa);
        await _context.SaveChangesAsync();
        return pessoa;
    }
}