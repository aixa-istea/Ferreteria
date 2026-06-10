namespace Ferreteria.API.DTOs;

public class VentaDto
{
    public int IdVenta { get; set; }
    public DateOnly Fecha { get; set; }
    public decimal TotalVenta { get; set; }
    public string MedioPago { get; set; } = null!;
    public string EstadoVenta { get; set; } = null!;
    public string Usuario { get; set; } = null!;
    public List<DetalleVentaDto> Detalles { get; set; } = new();
}

public class DetalleVentaDto
{
    public int IdProducto { get; set; }
    public string Descripcion { get; set; } = null!;
    public int Cantidad { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal Subtotal => Cantidad * PrecioVenta;
    public string Cliente { get; set; } = null!;
}


public class CrearVentaDto
{
    public int IdMedioDePago { get; set; }
    public int IdUsuario { get; set; }
    public List<CrearDetalleVentaDto> Detalles { get; set; } = new();
}

public class CrearDetalleVentaDto
{
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public int IdCliente { get; set; }
}