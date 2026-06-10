using Ferreteria.Data.EF;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.Repositories.Implementations;

public class VentaRepository : IVentaRepository
{
    private readonly FerreteriaDbContext _context;

    public VentaRepository(FerreteriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Venta
            .Include(v => v.IdMedioDePagoNavigation)
            .Include(v => v.IdUsuarioNavigation)
            .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.IdProductoNavigation)
            .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.IdClienteNavigation)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<Venta?> GetByIdAsync(int id)
    {
        return await _context.Venta
            .Include(v => v.IdMedioDePagoNavigation)
            .Include(v => v.IdUsuarioNavigation)
            .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.IdProductoNavigation)
            .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.IdClienteNavigation)
            .FirstOrDefaultAsync(v => v.IdVenta == id);
    }

    public async Task<IEnumerable<Venta>> GetByFechaAsync(DateOnly desde, DateOnly hasta)
    {
        return await _context.Venta
            .Include(v => v.IdMedioDePagoNavigation)
            .Include(v => v.IdUsuarioNavigation)
            .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.IdProductoNavigation)
            .Where(v => v.Fecha >= desde && v.Fecha <= hasta)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<Venta> CreateAsync(Venta venta, List<DetalleVenta> detalles)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();

            foreach (var detalle in detalles)
            {
                detalle.IdVenta = venta.IdVenta;
                _context.DetalleVenta.Add(detalle);

                // Descontar stock
                var producto = await _context.Productos.FindAsync(detalle.IdProducto);
                if (producto != null)
                    producto.StockActual = (producto.StockActual ?? 0) - detalle.Cantidad;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return venta;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> AnularAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var venta = await _context.Venta
                .Include(v => v.DetalleVenta)
                .FirstOrDefaultAsync(v => v.IdVenta == id);

            if (venta == null) return false;
            if (venta.EstadoVenta == "anulada") return false;

            // Restaurar stock
            foreach (var detalle in venta.DetalleVenta)
            {
                var producto = await _context.Productos.FindAsync(detalle.IdProducto);
                if (producto != null)
                    producto.StockActual = (producto.StockActual ?? 0) + detalle.Cantidad;
            }

            venta.EstadoVenta = "anulada";
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}