using Ferreteria.API.DTOs;
using Ferreteria.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VentasController : ControllerBase
{
    private readonly IVentaService _service;

    public VentasController(IVentaService service)
    {
        _service = service;
    }

    // GET api/ventas
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET api/ventas/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var venta = await _service.GetByIdAsync(id);
        return venta == null ? NotFound() : Ok(venta);
    }

    // GET api/ventas/fecha?desde=2025-05-01&hasta=2025-05-31
    [HttpGet("fecha")]
    public async Task<IActionResult> GetByFecha(
        [FromQuery] DateOnly desde,
        [FromQuery] DateOnly hasta)
        => Ok(await _service.GetByFechaAsync(desde, hasta));

    // POST api/ventas
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearVentaDto dto)
    {
        try
        {
            var creada = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creada.IdVenta }, creada);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PATCH api/ventas/5/anular
    [HttpPatch("{id}/anular")]
    public async Task<IActionResult> Anular(int id)
    {
        var resultado = await _service.AnularAsync(id);
        return resultado ? NoContent() : NotFound();
    }
}