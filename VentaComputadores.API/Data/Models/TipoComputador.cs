using System;
using System.Collections.Generic;

namespace VentaComputadores.API.Data.Models;

public partial class TipoComputador
{
    public int IdTipoComputador { get; set; }

    public string? NombreTipoComputador { get; set; }

    public virtual ICollection<Computador> Computadores { get; set; } = new List<Computador>();
}
