using Ferreteria.Data.Models;

namespace Ferreteria.API.Services;

public interface IReporteService
{
    Task<IEnumerable<VentasCompletas>> GetVentasCompletasAsync();
    Task<IEnumerable<ResumenClientes>> GetResumenClientesAsync();
    Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidosAsync();
    Task<IEnumerable<ResumenInventario>> GetResumenInventarioAsync();
}