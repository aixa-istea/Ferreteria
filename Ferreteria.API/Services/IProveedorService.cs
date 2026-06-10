using Ferreteria.API.DTOs;

namespace Ferreteria.API.Services;

public interface IProveedorService
{
    Task<IEnumerable<ProveedorDto>> GetAllAsync();
    Task<ProveedorDto?> GetByIdAsync(int id);
    Task<ProveedorDto?> GetByCuitAsync(string cuit);
    Task<ProveedorDto> CreateAsync(CrearProveedorDto dto);
    Task<ProveedorDto?> UpdateAsync(int id, ActualizarProveedorDto dto);
    Task<bool> DeleteAsync(int id);
}