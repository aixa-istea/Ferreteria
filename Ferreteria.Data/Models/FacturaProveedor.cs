using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class FacturaProveedor
{
    public int IdFactura { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int IdProveedor { get; set; }

    public decimal Total { get; set; }

    public string? EstadoFactura { get; set; }

    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<PagoProveedor> PagoProveedor { get; set; } = new List<PagoProveedor>();

    public virtual ICollection<RecepcionPedido> RecepcionPedido { get; set; } = new List<RecepcionPedido>();
}
