using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;

namespace Ferreteria.API.Services;

public class ReporteService : IReporteService
{
    private readonly IReporteRepository _repo;

    public ReporteService(IReporteRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<VentasCompletas>> GetVentasCompletasAsync()
        => await _repo.GetVentasCompletasAsync();

    public async Task<IEnumerable<ResumenClientes>> GetResumenClientesAsync()
        => await _repo.GetResumenClientesAsync();

    public async Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAsync()
        => await _repo.GetProductosMasVendidosAsync();

    public async Task<IEnumerable<ResumenInventario>> GetResumenInventarioAsync()
        => await _repo.GetResumenInventarioAsync();
}