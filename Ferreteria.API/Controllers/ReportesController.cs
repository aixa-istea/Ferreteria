using Ferreteria.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportesController : ControllerBase
{
    private readonly IReporteService _service;

    public ReportesController(IReporteService service)
    {
        _service = service;
    }

    // GET api/reportes/ventas
    [HttpGet("ventas")]
    public async Task<IActionResult> GetVentasCompletas()
        => Ok(await _service.GetVentasCompletasAsync());

    // GET api/reportes/clientes
    [HttpGet("clientes")]
    public async Task<IActionResult> GetResumenClientes()
        => Ok(await _service.GetResumenClientesAsync());

    // GET api/reportes/productos-mas-vendidos
    [HttpGet("productos-mas-vendidos")]
    public async Task<IActionResult> GetProductosMasVendidos()
        => Ok(await _service.GetProductosMasVendidosAsync());

    // GET api/reportes/inventario
    [HttpGet("inventario")]
    public async Task<IActionResult> GetResumenInventario()
        => Ok(await _service.GetResumenInventarioAsync());
}