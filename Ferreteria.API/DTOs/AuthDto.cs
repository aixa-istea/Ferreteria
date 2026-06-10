namespace Ferreteria.API.DTOs;

public class LoginDto
{
    public string UsuarioLogin { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginResponseDto
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string UsuarioLogin { get; set; } = null!;
    public string Rol { get; set; } = null!;
}