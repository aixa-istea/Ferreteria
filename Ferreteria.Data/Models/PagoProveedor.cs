using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class PagoProveedor
{
    public int IdPago { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdFacturaProveedor { get; set; }

    public decimal Total { get; set; }

    public int IdMedioPago { get; set; }

    public int IdUsuario { get; set; }

    public virtual FacturaProveedor IdFacturaProveedorNavigation { get; set; } = null!;

    public virtual MedioPago IdMedioPagoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
