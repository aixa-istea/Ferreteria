using Ferreteria.API.DTOs;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Ferreteria.API.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes).ToLower();
    }

    private static UsuarioDto ToDto(Usuarios u) => new()
    {
        IdUsuario = u.IdUsuario,
        Nombre = u.Nombre,
        Apellido = u.Apellido,
        Telefono = u.Telefono,
        Email = u.Email,
        UsuarioLogin = u.UsuarioLogin,
        Rol = u.IdRolNavigation?.Nombre ?? ""
    };

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        => (await _repo.GetAllAsync()).Select(ToDto);

    public async Task<UsuarioDto?> GetByIdAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        return u == null ? null : ToDto(u);
    }
    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
         var hash = HashPassword(dto.Password);
        var usuario = await _repo.GetByLoginYHashAsync(dto.UsuarioLogin, hash);
        if (usuario == null) return null;

         return new LoginResponseDto
        {
            IdUsuario = usuario.IdUsuario,
             Nombre = usuario.Nombre,
             Apellido = usuario.Apellido,
             UsuarioLogin = usuario.UsuarioLogin,
             Rol = usuario.IdRolNavigation?.Nombre ?? ""
         };
    }

    public async Task<UsuarioDto> CreateAsync(CrearUsuarioDto dto)
    {
        var usuario = new Usuarios
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Telefono = dto.Telefono,
            Email = dto.Email,
            UsuarioLogin = dto.UsuarioLogin,
            PasswordHash = HashPassword(dto.Password),
            IdRol = dto.IdRol
        };
        var creado = await _repo.CreateAsync(usuario);
        // recargar con navegación para el rol
        var conRol = await _repo.GetByIdAsync(creado.IdUsuario);
        return ToDto(conRol!);
    }

    public async Task<UsuarioDto?> UpdateAsync(int id, ActualizarUsuarioDto dto)
    {
        var usuarioActualizado = new Usuarios
        {
            Nombre = dto.Nombre!,
            Apellido = dto.Apellido!,
            Telefono = dto.Telefono,
            Email = dto.Email,
            IdRol = dto.IdRol ?? 0
        };
        var resultado = await _repo.UpdateAsync(id, usuarioActualizado);
        return resultado == null ? null : ToDto(resultado);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repo.DeleteAsync(id);
}