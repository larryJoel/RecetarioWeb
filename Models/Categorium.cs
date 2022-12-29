using System;
using System.Collections.Generic;

namespace Recetario.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Concepto { get; set; }
}
