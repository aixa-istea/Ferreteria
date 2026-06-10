using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class Proveedores
{
    public int IdProveedor { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<FacturaProveedor> FacturaProveedor { get; set; } = new List<FacturaProveedor>();

    public virtual ICollection<PedidoProveedor> PedidoProveedor { get; set; } = new List<PedidoProveedor>();

    public virtual ICollection<Productos> IdProducto { get; set; } = new List<Productos>();
}
