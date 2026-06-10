using Ferreteria.API.DTOs;

namespace Ferreteria.API.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> GetAllAsync();
    Task<UsuarioDto?> GetByIdAsync(int id);
    Task<UsuarioDto> CreateAsync(CrearUsuarioDto dto);
    Task<UsuarioDto?> UpdateAsync(int id, ActualizarUsuarioDto dto);
    Task<bool> DeleteAsync(int id);
}