using Ferreteria.Data.Models;

namespace Ferreteria.Data.Repositories.Interfaces;

public interface IVentaRepository
{
    Task<IEnumerable<Venta>> GetAllAsync();
    Task<Venta?> GetByIdAsync(int id);
    Task<IEnumerable<Venta>> GetByFechaAsync(DateOnly desde, DateOnly hasta);
    Task<Venta> CreateAsync(Venta venta, List<DetalleVenta> detalles);
    Task<bool> AnularAsync(int id);
}