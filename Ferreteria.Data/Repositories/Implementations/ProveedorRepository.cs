using Ferreteria.Data.EF;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.Repositories.Implementations;

public class ProveedorRepository : IProveedorRepository
{
    private readonly FerreteriaDbContext _context;

    public ProveedorRepository(FerreteriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Proveedores>> GetAllAsync()
    {
        return await _context.Proveedores
            .OrderBy(p => p.RazonSocial)
            .ToListAsync();
    }

    public async Task<Proveedores?> GetByIdAsync(int id)
    {
        return await _context.Proveedores
            .FirstOrDefaultAsync(p => p.IdProveedor == id);
    }

    public async Task<Proveedores?> GetByCuitAsync(string cuit)
    {
        return await _context.Proveedores
            .FirstOrDefaultAsync(p => p.Cuit == cuit);
    }

    public async Task<Proveedores> CreateAsync(Proveedores proveedor)
    {
        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();
        return proveedor;
    }

    public async Task<Proveedores?> UpdateAsync(int id, Proveedores proveedorActualizado)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null) return null;

        if (proveedorActualizado.RazonSocial != null)
            proveedor.RazonSocial = proveedorActualizado.RazonSocial;
        if (proveedorActualizado.Direccion != null)
            proveedor.Direccion = proveedorActualizado.Direccion;
        if (proveedorActualizado.Telefono != null)
            proveedor.Telefono = proveedorActualizado.Telefono;
        if (proveedorActualizado.Email != null)
            proveedor.Email = proveedorActualizado.Email;

        await _context.SaveChangesAsync();
        return proveedor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null) return false;

        _context.Proveedores.Remove(proveedor);
        await _context.SaveChangesAsync();
        return true;
    }
}