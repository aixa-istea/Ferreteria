namespace Ferreteria.API.DTOs;

public class UsuarioDto
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string UsuarioLogin { get; set; } = null!;
    public string Rol { get; set; } = null!;
}

public class CrearUsuarioDto
{
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string UsuarioLogin { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public int IdRol { get; set; }
}

public class ActualizarUsuarioDto
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public int? IdRol { get; set; }
}