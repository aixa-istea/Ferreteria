using Ferreteria.Data.Models;

namespace Ferreteria.Data.Repositories.Interfaces;

public interface IProductoRepository
{
    Task<IEnumerable<Productos>> GetAllAsync();
    Task<Productos?> GetByIdAsync(int id);
    Task<IEnumerable<Productos>> GetBajoStockAsync();
    Task<IEnumerable<Productos>> GetByCategoriaAsync(int idCategoria);
    Task<Productos> CreateAsync(Productos producto);
    Task<Productos?> UpdateAsync(int id, Productos producto);
    Task<bool> DeleteAsync(int id);
}