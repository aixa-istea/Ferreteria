using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class Productos
{
    public int IdProducto { get; set; }

    public int IdMarca { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public int? StockActual { get; set; }

    public int? StockMinimo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<DetallePedidoProveedor> DetallePedidoProveedor { get; set; } = new List<DetallePedidoProveedor>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Marcas IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<RecepcionDetalle> RecepcionDetalle { get; set; } = new List<RecepcionDetalle>();

    public virtual ICollection<CategoriasProducto> IdCategoria { get; set; } = new List<CategoriasProducto>();

    public virtual ICollection<Proveedores> IdProveedor { get; set; } = new List<Proveedores>();
}
