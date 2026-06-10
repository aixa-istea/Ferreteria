using Ferreteria.Data.EF;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.Repositories.Implementations;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly FerreteriaDbContext _context;

    public UsuarioRepository(FerreteriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuarios>> GetAllAsync()
    {
        return await _context.Usuarios
            .Include(u => u.IdRolNavigation)
            .OrderBy(u => u.Apellido)
            .ToListAsync();
    }

    public async Task<Usuarios?> GetByLoginYHashAsync(string usuarioLogin, string passwordHash)
    {
         return await _context.Usuarios
            .Include(u => u.IdRolNavigation)
            .FirstOrDefaultAsync(u => u.UsuarioLogin == usuarioLogin
                                    && u.PasswordHash == passwordHash);
    }
    public async Task<Usuarios?> GetByIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.IdRolNavigation)
            .FirstOrDefaultAsync(u => u.IdUsuario == id);
    }

    public async Task<Usuarios?> GetByLoginAsync(string usuarioLogin)
    {
        return await _context.Usuarios
            .Include(u => u.IdRolNavigation)
            .FirstOrDefaultAsync(u => u.UsuarioLogin == usuarioLogin);
    }

    public async Task<Usuarios> CreateAsync(Usuarios usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuarios?> UpdateAsync(int id, Usuarios usuarioActualizado)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return null;

        if (usuarioActualizado.Nombre != null)
            usuario.Nombre = usuarioActualizado.Nombre;
        if (usuarioActualizado.Apellido != null)
            usuario.Apellido = usuarioActualizado.Apellido;
        if (usuarioActualizado.Telefono != null)
            usuario.Telefono = usuarioActualizado.Telefono;
        if (usuarioActualizado.Email != null)
            usuario.Email = usuarioActualizado.Email;
        if (usuarioActualizado.IdRol != 0)
            usuario.IdRol = usuarioActualizado.IdRol;

        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}