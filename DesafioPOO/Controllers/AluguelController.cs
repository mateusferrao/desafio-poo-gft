using DesafioPOO.Models;
using DesafioPOO.Services;
using DesafioPOO.DTOs;
using DesafioPOO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AluguelController(AluguelService aluguelService, CorretoraContext context) : ControllerBase
{
    private readonly AluguelService _aluguelService = aluguelService;
    private readonly CorretoraContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alugueis = await _aluguelService.BuscarTodosAlugueisAsync();
        return Ok(alugueis);
    }

    [HttpGet("inquilino/{inquilinoId}")]
    public async Task<IActionResult> GetByInquilino(int inquilinoId)
    {
        var alugueis = await _aluguelService.BuscarAlugueisPorInquilinoAsync(inquilinoId);
        return Ok(alugueis);
    }

    [HttpGet("imovel/{imovelId}")]
    public async Task<IActionResult> GetByImovel(int imovelId)
    {
        var alugueis = await _aluguelService.BuscarAlugueisPorImovelAsync(imovelId);
        return Ok(alugueis);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var aluguel = await _aluguelService.BuscarAluguelPorIdAsync(id);
        if (aluguel == null)
        {
            return NotFound();
        }
        return Ok(aluguel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AluguelCreateDto aluguelDto)
    {
        // Buscar imóvel e inquilino
        var imovel = await _context.Imoveis.FindAsync(aluguelDto.ImovelId);
        var inquilino = await _context.Pessoas.OfType<Inquilino>().FirstOrDefaultAsync(p => p.Id == aluguelDto.InquilinoId);

        if (imovel == null || inquilino == null)
        {
            return BadRequest("Imóvel ou inquilino não encontrado.");
        }

        var aluguel = new Aluguel(
            imovel,
            inquilino,
            aluguelDto.DataInicio,
            aluguelDto.DataFim,
            aluguelDto.Valor
        );

        var aluguelCriado = await _aluguelService.AdicionarAluguelAsync(aluguel);
        return CreatedAtAction(nameof(GetById), new { id = aluguelCriado.Id }, aluguelCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AluguelUpdateDto aluguelDto)
    {
        var aluguelExistente = await _aluguelService.BuscarAluguelPorIdAsync(id);
        if (aluguelExistente == null)
        {
            return NotFound();
        }

        // Buscar imóvel e inquilino
        var imovel = await _context.Imoveis.FindAsync(aluguelDto.ImovelId);
        var inquilino = await _context.Pessoas.OfType<Inquilino>().FirstOrDefaultAsync(p => p.Id == aluguelDto.InquilinoId);

        if (imovel == null || inquilino == null)
        {
            return BadRequest("Imóvel ou inquilino não encontrado.");
        }

        aluguelExistente.SetImovel(imovel);
        aluguelExistente.SetInquilino(inquilino);
        aluguelExistente.SetDataInicio(aluguelDto.DataInicio);
        aluguelExistente.SetDataFim(aluguelDto.DataFim);
        aluguelExistente.SetValor(aluguelDto.Valor);

        var aluguelAtualizado = await _aluguelService.AtualizarAluguelAsync(aluguelExistente);
        return Ok(aluguelAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var aluguel = await _aluguelService.BuscarAluguelPorIdAsync(id);
        if (aluguel == null)
        {
            return NotFound();
        }

        await _aluguelService.DeletarAluguelAsync(id);
        return NoContent();
    }
}
