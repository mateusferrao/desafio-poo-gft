using DesafioPOO.Data;
using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Repositories;

public class EnderecoRepository
{
    private readonly CorretoraContext _context;

    public EnderecoRepository(CorretoraContext context)
    {
        _context = context;
    }

    public async Task<List<Endereco>> GetAllAsync()
    {
        return await _context.Enderecos.ToListAsync();
    }

    public async Task<Endereco?> GetByIdAsync(int id)
    {
        return await _context.Enderecos.FindAsync(id);
    }

    public async Task<Endereco> AddAsync(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();
        return endereco;
    }

    public async Task<Endereco> UpdateAsync(Endereco endereco)
    {
        _context.Enderecos.Update(endereco);
        await _context.SaveChangesAsync();
        return endereco;
    }

    public async Task<Endereco> DeleteAsync(Endereco endereco)
    {
        _context.Enderecos.Remove(endereco);
        await _context.SaveChangesAsync();
        return endereco;
    }
}
