using System;
using System.Collections.Generic;

namespace Recetario.Models;

public partial class Receta
{
    public int IdRecetas { get; set; }

    public string? Titulo { get; set; }

    public string? Categoria { get; set; }

    public string? Descripcion { get; set; }

    public int? CantComensales { get; set; }

    public string? Origen { get; set; }

    public string? Preparacion { get; set; }

    public int? Valoracion { get; set; }

    public string? Imagen { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Ingrediente> Ingredientes { get; } = new List<Ingrediente>();
}
