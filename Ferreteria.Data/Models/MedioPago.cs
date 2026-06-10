using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class MedioPago
{
    public int IdMedioDePago { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PagoProveedor> PagoProveedor { get; set; } = new List<PagoProveedor>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
