using Ferreteria.Data.EF;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.Repositories.Implementations;

public class ReporteRepository : IReporteRepository
{
    private readonly FerreteriaDbContext _context;

    public ReporteRepository(FerreteriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VentasCompletas>> GetVentasCompletasAsync()
        => await _context.VentasCompletas.ToListAsync();

    public async Task<IEnumerable<ResumenClientes>> GetResumenClientesAsync()
        => await _context.ResumenClientes
            .OrderByDescending(c => c.TotalGastado)
            .ToListAsync();

    public async Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAsync()
        => await _context.ProductosMasVendidos
            .OrderByDescending(p => p.TotalUnidadesVendidas)
            .ToListAsync();

    public async Task<IEnumerable<ResumenInventario>> GetResumenInventarioAsync()
        => await _context.ResumenInventario.ToListAsync();
}