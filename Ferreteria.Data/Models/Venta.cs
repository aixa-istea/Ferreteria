using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal TotalVenta { get; set; }

    public int IdMedioDePago { get; set; }

    public string? EstadoVenta { get; set; }

    public int IdUsuario { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual MedioPago IdMedioDePagoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
