using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class RecepcionDetalle
{
    public int IdRecepcion { get; set; }

    public int IdProducto { get; set; }

    public int CantidadRecibida { get; set; }

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual RecepcionPedido IdRecepcionNavigation { get; set; } = null!;
}
