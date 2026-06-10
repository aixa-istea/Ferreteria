using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string UsuarioLogin { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual Roles IdRolNavigation { get; set; } = null!;

    public virtual ICollection<PagoProveedor> PagoProveedor { get; set; } = new List<PagoProveedor>();

    public virtual ICollection<PedidoProveedor> PedidoProveedor { get; set; } = new List<PedidoProveedor>();

    public virtual ICollection<RecepcionPedido> RecepcionPedido { get; set; } = new List<RecepcionPedido>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
