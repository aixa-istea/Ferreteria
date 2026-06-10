using Ferreteria.API.DTOs;

namespace Ferreteria.API.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(int id);
    Task<ClienteDto?> GetByDocumentoAsync(string numeroDocumento);
    Task<ClienteDto> CreateAsync(CrearClienteDto dto);
    Task<ClienteDto?> UpdateAsync(int id, ActualizarClienteDto dto);
    Task<bool> DeleteAsync(int id);
}