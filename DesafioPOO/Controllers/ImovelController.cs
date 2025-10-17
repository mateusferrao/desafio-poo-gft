using DesafioPOO.Models;
using DesafioPOO.Services;
using DesafioPOO.DTOs;
using DesafioPOO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImovelController(ImovelService imovelService, CorretoraContext context) : ControllerBase
{
    private readonly ImovelService _imovelService = imovelService;
    private readonly CorretoraContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var imoveis = await _imovelService.BuscarTodosImoveisAsync();
        return Ok(imoveis);
    }

    [HttpGet("casas")]
    public async Task<IActionResult> GetAllCasas()
    {
        var casas = await _imovelService.BuscarTodasCasasAsync();
        return Ok(casas);
    }

    [HttpGet("apartamentos")]
    public async Task<IActionResult> GetAllApartamentos()
    {
        var apartamentos = await _imovelService.BuscarTodosApartamentosAsync();
        return Ok(apartamentos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var imovel = await _imovelService.BuscarImovelPorIdAsync(id);
        if (imovel == null)
        {
            return NotFound();
        }
        return Ok(imovel);
    }

    [HttpPost("casa")]
    public async Task<IActionResult> AddCasa([FromBody] CasaCreateDto casaDto)
    {
        // Buscar endereço e proprietário
        var endereco = await _context.Enderecos.FindAsync(casaDto.EnderecoId);
        var proprietario = await _context.Pessoas.OfType<Proprietario>().FirstOrDefaultAsync(p => p.Id == casaDto.ProprietarioId);

        if (endereco == null || proprietario == null)
        {
            return BadRequest("Endereço ou proprietário não encontrado.");
        }

        var casa = new Casa(
            endereco,
            casaDto.Alugado,
            proprietario,
            casaDto.Tamanho,
            casaDto.NumeroQuartos,
            casaDto.NumeroBanheiros,
            casaDto.TemGaragem
        );

        var casaCriada = await _imovelService.AdicionarImovelAsync(casa);
        return CreatedAtAction(nameof(GetById), new { id = casaCriada.Id }, casaCriada);
    }

    [HttpPost("apartamento")]
    public async Task<IActionResult> AddApartamento([FromBody] ApartamentoCreateDto apartamentoDto)
    {
        // Buscar endereço e proprietário
        var endereco = await _context.Enderecos.FindAsync(apartamentoDto.EnderecoId);
        var proprietario = await _context.Pessoas.OfType<Proprietario>().FirstOrDefaultAsync(p => p.Id == apartamentoDto.ProprietarioId);

        if (endereco == null || proprietario == null)
        {
            return BadRequest("Endereço ou proprietário não encontrado.");
        }

        var apartamento = new Apartamento(
            endereco,
            apartamentoDto.Alugado,
            proprietario,
            apartamentoDto.Tamanho,
            apartamentoDto.Andar,
            apartamentoDto.NumeroApartamento
        );

        var apartamentoCriado = await _imovelService.AdicionarImovelAsync(apartamento);
        return CreatedAtAction(nameof(GetById), new { id = apartamentoCriado.Id }, apartamentoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ImovelUpdateDto imovelDto)
    {
        var imovelExistente = await _imovelService.BuscarImovelPorIdAsync(id);
        if (imovelExistente == null)
        {
            return NotFound();
        }

        // Buscar endereço e proprietário
        var endereco = await _context.Enderecos.FindAsync(imovelDto.EnderecoId);
        var proprietario = await _context.Pessoas.OfType<Proprietario>().FirstOrDefaultAsync(p => p.Id == imovelDto.ProprietarioId);

        if (endereco == null || proprietario == null)
        {
            return BadRequest("Endereço ou proprietário não encontrado.");
        }

        imovelExistente.SetEndereco(endereco);
        imovelExistente.SetAlugado(imovelDto.Alugado);
        imovelExistente.SetProprietario(proprietario);
        imovelExistente.SetTamanho(imovelDto.Tamanho);

        var imovelAtualizado = await _imovelService.AtualizarImovelAsync(imovelExistente);
        return Ok(imovelAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var imovel = await _imovelService.BuscarImovelPorIdAsync(id);
        if (imovel == null)
        {
            return NotFound();
        }

        await _imovelService.DeletarImovelAsync(id);
        return NoContent();
    }
}
