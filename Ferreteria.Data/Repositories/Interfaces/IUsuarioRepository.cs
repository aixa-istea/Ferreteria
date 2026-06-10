using Ferreteria.Data.Models;

namespace Ferreteria.Data.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuarios>> GetAllAsync();
    Task<Usuarios?> GetByLoginYHashAsync(string usuarioLogin, string passwordHash);
    Task<Usuarios?> GetByIdAsync(int id);
    Task<Usuarios?> GetByLoginAsync(string usuarioLogin);
    Task<Usuarios> CreateAsync(Usuarios usuario);
    Task<Usuarios?> UpdateAsync(int id, Usuarios usuario);
    Task<bool> DeleteAsync(int id);
}