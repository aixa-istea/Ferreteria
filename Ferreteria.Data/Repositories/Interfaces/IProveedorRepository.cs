using Ferreteria.Data.Models;

namespace Ferreteria.Data.Repositories.Interfaces;

public interface IProveedorRepository
{
    Task<IEnumerable<Proveedores>> GetAllAsync();
    Task<Proveedores?> GetByIdAsync(int id);
    Task<Proveedores?> GetByCuitAsync(string cuit);
    Task<Proveedores> CreateAsync(Proveedores proveedor);
    Task<Proveedores?> UpdateAsync(int id, Proveedores proveedor);
    Task<bool> DeleteAsync(int id);
}