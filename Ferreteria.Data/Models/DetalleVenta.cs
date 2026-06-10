using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class DetalleVenta
{
    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioVenta { get; set; }

    public int IdCliente { get; set; }

    public virtual Clientes IdClienteNavigation { get; set; } = null!;

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
