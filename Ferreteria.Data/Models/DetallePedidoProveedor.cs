using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class DetallePedidoProveedor
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal Subtotal { get; set; }

    public virtual PedidoProveedor IdPedidoNavigation { get; set; } = null!;

    public virtual Productos IdProductoNavigation { get; set; } = null!;
}
