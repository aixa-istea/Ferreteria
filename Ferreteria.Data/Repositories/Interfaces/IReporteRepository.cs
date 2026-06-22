using Ferreteria.Data.Models;

namespace Ferreteria.Data.Repositories.Interfaces;

public interface IReporteRepository
{
    Task<IEnumerable<VentasCompletas>> GetVentasCompletasAsync();
    Task<IEnumerable<ResumenClientes>> GetResumenClientesAsync();
    Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAsync();
    Task<IEnumerable<ResumenInventario>> GetResumenInventarioAsync();
}