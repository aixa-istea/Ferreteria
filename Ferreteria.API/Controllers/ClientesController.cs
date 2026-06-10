using Ferreteria.API.DTOs;
using Ferreteria.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    // GET api/clientes
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET api/clientes/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _service.GetByIdAsync(id);
        return cliente == null ? NotFound() : Ok(cliente);
    }

    // GET api/clientes/documento/28456789
    [HttpGet("documento/{numeroDocumento}")]
    public async Task<IActionResult> GetByDocumento(string numeroDocumento)
    {
        var cliente = await _service.GetByDocumentoAsync(numeroDocumento);
        return cliente == null ? NotFound() : Ok(cliente);
    }

    // POST api/clientes
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearClienteDto dto)
    {
        var creado = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdCliente }, creado);
    }

    // PUT api/clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ActualizarClienteDto dto)
    {
        var resultado = await _service.UpdateAsync(id, dto);
        return resultado == null ? NotFound() : Ok(resultado);
    }

    // DELETE api/clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);
        return eliminado ? NoContent() : NotFound();
    }
}