using Ferreteria.API.DTOs;
using Ferreteria.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    // GET api/productos
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET api/productos/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _service.GetByIdAsync(id);
        return producto == null ? NotFound() : Ok(producto);
    }

    // GET api/productos/bajo-stock
    [HttpGet("bajo-stock")]
    public async Task<IActionResult> GetBajoStock()
        => Ok(await _service.GetBajoStockAsync());

    // GET api/productos/categoria/3
    [HttpGet("categoria/{idCategoria}")]
    public async Task<IActionResult> GetByCategoria(int idCategoria)
        => Ok(await _service.GetByCategoriaAsync(idCategoria));

    // POST api/productos
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearProductoDto dto)
    {
        var creado = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdProducto }, creado);
    }

    // PUT api/productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ActualizarProductoDto dto)
    {
        var resultado = await _service.UpdateAsync(id, dto);
        return resultado == null ? NotFound() : Ok(resultado);
    }

    // DELETE api/productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);
        return eliminado ? NoContent() : NotFound();
    }
}