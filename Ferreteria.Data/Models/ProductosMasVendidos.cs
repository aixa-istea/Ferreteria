using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class ProductosMasVendidos
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? TotalUnidadesVendidas { get; set; }

    public decimal? IngresosGenerados { get; set; }
}
