using System;
using System.Collections.Generic;

namespace Ferreteria.Data.Models;

public partial class Marcas
{
    public int IdMarca { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
