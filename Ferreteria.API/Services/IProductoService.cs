using Ferreteria.API.DTOs;

namespace Ferreteria.API.Services;

public interface IProductoService
{
    Task<IEnumerable<ProductoDto>> GetAllAsync();
    Task<ProductoDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductoDto>> GetBajoStockAsync();
    Task<IEnumerable<ProductoDto>> GetByCategoriaAsync(int idCategoria);
    Task<ProductoDto> CreateAsync(CrearProductoDto dto);
    Task<ProductoDto?> UpdateAsync(int id, ActualizarProductoDto dto);
    Task<bool> DeleteAsync(int id);
}