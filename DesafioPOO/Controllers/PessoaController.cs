using DesafioPOO.Models;
using DesafioPOO.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPOO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController(PessoaService pessoaService) : ControllerBase
{
    private readonly PessoaService _pessoaService = pessoaService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pessoas = await _pessoaService.BuscarTodasPessoasAsync();
        return Ok(pessoas);
    }

    [HttpGet("inquilinos")]
    public async Task<IActionResult> GetAllInquilinos()
    {
        var inquilinos = await _pessoaService.BuscarTodosInquilinosAsync();
        return Ok(inquilinos);
    }

    [HttpGet("proprietarios")]
    public async Task<IActionResult> GetAllProprietarios()
    {
        var proprietarios = await _pessoaService.BuscarTodosProprietariosAsync();
        return Ok(proprietarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pessoa = await _pessoaService.BuscarPessoaPorIdAsync(id);
        if (pessoa == null)
        {
            return NotFound();
        }
        return Ok(pessoa);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Pessoa pessoa)
    {
        await _pessoaService.AdicionarPessoaAsync(pessoa);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pessoa pessoa)
    {
        await _pessoaService.AtualizarPessoaAsync(pessoa);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _pessoaService.DeletarPessoaAsync(id);
        return NoContent();
    }
}