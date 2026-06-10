using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class CategoriasProducto
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Productos> IdProducto { get; set; } = new List<Productos>();
}
