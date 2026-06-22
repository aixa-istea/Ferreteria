using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class VentasCompletas
{
    public int IdVenta { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Cliente { get; set; }

    public string Producto { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal SubtotalLinea { get; set; }

    public string MedioPago { get; set; } = null!;

    public string Vendedor { get; set; } = null!;

    public string? EstadoVenta { get; set; }
}
