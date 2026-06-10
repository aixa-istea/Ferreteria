using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class RecepcionPedido
{
    public int IdRecepcion { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdPedidoProveedor { get; set; }

    public int IdFacturaProveedor { get; set; }

    public int IdUsuario { get; set; }

    public virtual FacturaProveedor IdFacturaProveedorNavigation { get; set; } = null!;

    public virtual PedidoProveedor IdPedidoProveedorNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<RecepcionDetalle> RecepcionDetalle { get; set; } = new List<RecepcionDetalle>();
}
