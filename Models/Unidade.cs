using System;
using System.Collections.Generic;

namespace Recetario.Models;

public partial class Unidade
{
    public int IdUnidad { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Ingrediente> Ingredientes { get; } = new List<Ingrediente>();
}
