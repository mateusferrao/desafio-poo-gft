using DesafioPOO.Models;
using DesafioPOO.Services;
using DesafioPOO.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPOO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController(EnderecoService enderecoService) : ControllerBase
{
    private readonly EnderecoService _enderecoService = enderecoService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var enderecos = await _enderecoService.BuscarTodosEnderecosAsync();
        return Ok(enderecos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }
        return Ok(endereco);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] EnderecoCreateDto enderecoDto)
    {
        var endereco = new Endereco(
            enderecoDto.Rua,
            enderecoDto.Numero,
            enderecoDto.Bairro,
            enderecoDto.Complemento,
            enderecoDto.Cidade,
            enderecoDto.Estado,
            enderecoDto.Cep
        );

        var enderecoCriado = await _enderecoService.AdicionarEnderecoAsync(endereco);
        return CreatedAtAction(nameof(GetById), new { id = enderecoCriado.Id }, enderecoCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EnderecoUpdateDto enderecoDto)
    {
        var enderecoExistente = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (enderecoExistente == null)
        {
            return NotFound();
        }

        enderecoExistente.SetRua(enderecoDto.Rua);
        enderecoExistente.SetNumero(enderecoDto.Numero);
        enderecoExistente.SetBairro(enderecoDto.Bairro);
        enderecoExistente.SetComplemento(enderecoDto.Complemento);
        enderecoExistente.SetCidade(enderecoDto.Cidade);
        enderecoExistente.SetEstado(enderecoDto.Estado);
        enderecoExistente.SetCep(enderecoDto.Cep);

        var enderecoAtualizado = await _enderecoService.AtualizarEnderecoAsync(enderecoExistente);
        return Ok(enderecoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }

        await _enderecoService.DeletarEnderecoAsync(id);
        return NoContent();
    }
}
