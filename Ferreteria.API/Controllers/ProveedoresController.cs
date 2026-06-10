using Ferreteria.API.DTOs;
using Ferreteria.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly IProveedorService _service;

    public ProveedoresController(IProveedorService service)
    {
        _service = service;
    }

    // GET api/proveedores
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET api/proveedores/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var proveedor = await _service.GetByIdAsync(id);
        return proveedor == null ? NotFound() : Ok(proveedor);
    }

    // GET api/proveedores/cuit/30-61234567-8
    [HttpGet("cuit/{cuit}")]
    public async Task<IActionResult> GetByCuit(string cuit)
    {
        var proveedor = await _service.GetByCuitAsync(cuit);
        return proveedor == null ? NotFound() : Ok(proveedor);
    }

    // POST api/proveedores
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearProveedorDto dto)
    {
        var creado = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdProveedor }, creado);
    }

    // PUT api/proveedores/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ActualizarProveedorDto dto)
    {
        var resultado = await _service.UpdateAsync(id, dto);
        return resultado == null ? NotFound() : Ok(resultado);
    }

    // DELETE api/proveedores/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);
        return eliminado ? NoContent() : NotFound();
    }
}