using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Recetario.Models;

public partial class Unidade
{
    
    public int IdUnidad { get; set; }
    
    [Required(ErrorMessage ="El nombre es obligatorio")]
    public string? Nombre { get; set; }
    
    [Required(ErrorMessage ="La descripcion es obligatoria")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Ingrediente> Ingredientes { get; } = new List<Ingrediente>();
}
