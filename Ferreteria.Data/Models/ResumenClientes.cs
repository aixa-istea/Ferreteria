using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class ResumenClientes
{
    public int IdCliente { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string? Cliente { get; set; }

    public long CantidadTickets { get; set; }

    public decimal? TotalGastado { get; set; }
}
