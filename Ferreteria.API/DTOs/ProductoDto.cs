namespace Ferreteria.API.DTOs;


public class ProductoDto
{
    public int IdProducto { get; set; }
    public string Descripcion { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public decimal PrecioCosto { get; set; }
    public decimal PrecioVenta { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public string Estado { get; set; } = null!;
    public bool BajoStock => StockActual <= StockMinimo;
}


public class CrearProductoDto
{
    public int IdMarca { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal PrecioCosto { get; set; }
    public decimal PrecioVenta { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
}


public class ActualizarProductoDto
{
    public string? Descripcion { get; set; }
    public decimal? PrecioCosto { get; set; }
    public decimal? PrecioVenta { get; set; }
    public int? StockActual { get; set; }
    public int? StockMinimo { get; set; }
    public string? Estado { get; set; }
}