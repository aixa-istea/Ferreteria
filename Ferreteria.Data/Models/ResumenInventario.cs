using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class ResumenInventario
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? StockActual { get; set; }

    public int? StockMinimo { get; set; }

    public decimal? ValorCostoTotal { get; set; }

    public decimal? ValorVentaEstimado { get; set; }

    public string EstadoStock { get; set; } = null!;
}
