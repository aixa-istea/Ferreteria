namespace Ferreteria.API.DTOs;

public class ProveedorDto
{
    public int IdProveedor { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string Cuit { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
}

public class CrearProveedorDto
{
    public string RazonSocial { get; set; } = null!;
    public string Cuit { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
}

public class ActualizarProveedorDto
{
    public string? RazonSocial { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
}