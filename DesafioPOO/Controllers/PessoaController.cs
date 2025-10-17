using DesafioPOO.Models;
using DesafioPOO.Services;
using DesafioPOO.DTOs;
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


    [HttpPost("inquilino")]
    public async Task<IActionResult> AddInquilino([FromBody] InquilinoCreateDto inquilinoDto)
    {
        var inquilino = new Inquilino(inquilinoDto.Nome, inquilinoDto.Telefone, inquilinoDto.Cpf);
        var inquilinoCriado = await _pessoaService.AdicionarPessoaAsync(inquilino);
        return CreatedAtAction(nameof(GetById), new { id = inquilinoCriado.Id }, inquilinoCriado);
    }

    [HttpPost("proprietario")]
    public async Task<IActionResult> AddProprietario([FromBody] ProprietarioCreateDto proprietarioDto)
    {
        var proprietario = new Proprietario(proprietarioDto.Nome, proprietarioDto.Telefone, proprietarioDto.Cpf);
        var proprietarioCriado = await _pessoaService.AdicionarPessoaAsync(proprietario);
        return CreatedAtAction(nameof(GetById), new { id = proprietarioCriado.Id }, proprietarioCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PessoaUpdateDto pessoaDto)
    {
        var pessoaExistente = await _pessoaService.BuscarPessoaPorIdAsync(id);
        if (pessoaExistente == null)
        {
            return NotFound();
        }

        pessoaExistente.SetNome(pessoaDto.Nome);
        pessoaExistente.SetTelefone(pessoaDto.Telefone);
        pessoaExistente.SetCpf(pessoaDto.Cpf);

        var pessoaAtualizada = await _pessoaService.AtualizarPessoaAsync(pessoaExistente);
        return Ok(pessoaAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pessoa = await _pessoaService.BuscarPessoaPorIdAsync(id);
        if (pessoa == null)
        {
            return NotFound();
        }
        await _pessoaService.DeletarPessoaAsync(id);
        return NoContent();
    }
}