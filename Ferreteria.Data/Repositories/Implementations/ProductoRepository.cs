using Ferreteria.Data.EF;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.Repositories.Implementations;

public class ProductoRepository : IProductoRepository
{
    private readonly FerreteriaDbContext _context;

    public ProductoRepository(FerreteriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Productos>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.IdMarcaNavigation)
            .Where(p => p.Estado != "eliminado")
            .ToListAsync();
    }

    public async Task<Productos?> GetByIdAsync(int id)
    {
        return await _context.Productos
            .Include(p => p.IdMarcaNavigation)
            .FirstOrDefaultAsync(p => p.IdProducto == id && p.Estado != "eliminado");
    }

    public async Task<IEnumerable<Productos>> GetBajoStockAsync()
    {
        return await _context.Productos
            .Include(p => p.IdMarcaNavigation)
            .Where(p => p.Estado == "activo" && p.StockActual <= p.StockMinimo)
            .ToListAsync();
    }

    public async Task<IEnumerable<Productos>> GetByCategoriaAsync(int idCategoria)
    {
        return await _context.Productos
            .Include(p => p.IdMarcaNavigation)
            .Where(p => p.Estado != "eliminado" &&
                        p.IdCategoria.Any(c => c.IdCategoria == idCategoria))
            .ToListAsync();
    }

    public async Task<Productos> CreateAsync(Productos producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Productos?> UpdateAsync(int id, Productos productoActualizado)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return null;

        if (productoActualizado.Descripcion != null)
            producto.Descripcion = productoActualizado.Descripcion;
        if (productoActualizado.PrecioCosto > 0)
            producto.PrecioCosto = productoActualizado.PrecioCosto;
        if (productoActualizado.PrecioVenta > 0)
            producto.PrecioVenta = productoActualizado.PrecioVenta;
        if (productoActualizado.StockActual >= 0)
            producto.StockActual = productoActualizado.StockActual;
        if (productoActualizado.StockMinimo >= 0)
            producto.StockMinimo = productoActualizado.StockMinimo;
        if (productoActualizado.Estado != null)
            producto.Estado = productoActualizado.Estado;

        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Estado = "eliminado"; // baja lógica
        await _context.SaveChangesAsync();
        return true;
    }
}