using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class PedidoProveedor
{
    public int IdPedido { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdProveedor { get; set; }

    public string? Estado { get; set; }

    public int IdUsuario { get; set; }

    public virtual ICollection<DetallePedidoProveedor> DetallePedidoProveedor { get; set; } = new List<DetallePedidoProveedor>();

    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<RecepcionPedido> RecepcionPedido { get; set; } = new List<RecepcionPedido>();
}
